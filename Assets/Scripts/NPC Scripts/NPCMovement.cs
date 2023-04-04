using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class NPCMovement : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent NPC;
    [HideInInspector] public List<GameObject> NPCDestinations = new List<GameObject>();
    [HideInInspector] public Vector3 ExitLocation;

    public bool isAtDestination = false;
    private bool isCoroutineExecuting = false;

    public bool isFleeing = false;

    // Start is called before the first frame update
    public virtual void Start()
    {
        NPC = GetComponent<NavMeshAgent>();
        ExitLocation = GameObject.FindGameObjectWithTag("Exit").transform.position;

        InitializeMovement();
    }

    public virtual void InitializeMovement(){

    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public IEnumerator ExecuteAfterTime(float time){
        if (isCoroutineExecuting)
         yield break;
 
        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        MoveNPC();

        isCoroutineExecuting = false;
    }

    public virtual void MoveNPC(){

    }
}