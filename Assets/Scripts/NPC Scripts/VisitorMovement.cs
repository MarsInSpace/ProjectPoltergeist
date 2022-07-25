using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class VisitorMovement : MonoBehaviour
{
    private NavMeshAgent Visitor;
    private List<GameObject> VisitorGoals = new List<GameObject>();

    private GameObject RandomGoal;
    private Transform GoalLocation;

    public bool isAtDestination = false;
    private bool isCoroutineExecuting = false;

    void Start(){
        Visitor = GetComponent<NavMeshAgent>();

        foreach (GameObject visitorGoal in GameObject.FindGameObjectsWithTag("VisitorGoals")){
            VisitorGoals.Add(visitorGoal);
        }
    }

    void Update(){
        if(GoalLocation == null){
            PickRandomGoal();
        }
        if(isAtDestination){
            StartCoroutine(ExecuteAfterTime(5f));
        }
        Console.WriteLine(Visitor.destination);
    }

    IEnumerator ExecuteAfterTime(float time){
        if (isCoroutineExecuting)
         yield break;
 
        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        PickRandomGoal();

        isCoroutineExecuting = false;
    }

    private void PickRandomGoal(){
        int randomIndex = Random.Range(0, VisitorGoals.Count);
        RandomGoal = VisitorGoals[randomIndex];
        GoalLocation = RandomGoal.transform;

        Visitor.destination = GoalLocation.position;
        isAtDestination = false;
    }
}
