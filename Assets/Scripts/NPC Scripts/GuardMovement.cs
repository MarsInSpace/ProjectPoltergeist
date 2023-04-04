using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : NPCMovement
{
    int currentPatrolStop;
    private GameObject FirstStop;
    private GameObject NextStop;
    float guardWaitingTime = 5f;
    bool isMovingToStartingPoint = false;
    
    public override void Start()
    {
        base.Start();
        currentPatrolStop = 0;
    }

    public override void Update()
    {
        base.Update();
        if(NextStop == null){
            MoveToNextPatrolStop();
        }
        if(isAtDestination && currentPatrolStop != 0){
            StartCoroutine(ExecuteAfterTime(guardWaitingTime));
        }
    }

    public override void InitializeMovement(){
        //base.InitializeMovement();

        foreach (GameObject destination in GameObject.FindGameObjectsWithTag("PatrolStop")){
            NPCDestinations.Add(destination);
        }

        FirstStop = NPCDestinations[0];
    }

    public override void MoveNPC()
    {
        //base.MoveNPC();
        MoveToNextPatrolStop();
    }

    void MoveToNextPatrolStop(){
        NextStop = NPCDestinations[currentPatrolStop];
        NPC.destination = NextStop.transform.position;
        isAtDestination = false;

        currentPatrolStop++;
        Debug.Log(currentPatrolStop);
        if(currentPatrolStop > (NPCDestinations.Count - 1)){
            currentPatrolStop = 0;
            StartCoroutine(MoveToStartingPoint(guardWaitingTime));
        }
    }

    public IEnumerator MoveToStartingPoint(float time){
        if (isMovingToStartingPoint)
         yield break;
 
        isMovingToStartingPoint = true;

        yield return new WaitForSeconds(time);

        NPC.destination = FirstStop.transform.position;

        isMovingToStartingPoint = false;
        StartCoroutine(ExecuteAfterTime(guardWaitingTime));
    }
}
