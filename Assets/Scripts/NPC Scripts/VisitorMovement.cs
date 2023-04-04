using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorMovement : NPCMovement
{
    private GameObject RandomGoal;
    private Transform GoalLocation;
    
    new void Start(){
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        if(isFleeing) {
            StopAllCoroutines();
            return;
        }

        if(GoalLocation == null && !isFleeing){
            PickRandomVisitorGoal();
        }
        if(isAtDestination && !isFleeing){
            StartCoroutine(ExecuteAfterTime(Random.Range(5f, 15f)));
        }
    }
    public override void InitializeMovement(){
        //base.InitializeMovement();
        
        foreach (GameObject destination in GameObject.FindGameObjectsWithTag("VisitorGoals")){
            NPCDestinations.Add(destination);
        }
    }

    public override void MoveNPC()
    {
        //base.MoveNPC();
        PickRandomVisitorGoal();
    }

    void PickRandomVisitorGoal(){
        int randomIndex = Random.Range(0, NPCDestinations.Count);
        RandomGoal = NPCDestinations[randomIndex];
        GoalLocation = RandomGoal.transform;

        NPC.destination = GoalLocation.position;
        isAtDestination = false;
    }

    public void OnFlight(){
        NPC.destination = ExitLocation;
        isFleeing = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Visitor" && !isFleeing) {
            PickRandomVisitorGoal();
            StartCoroutine(ExecuteAfterTime(0f));
        }
    }
}
