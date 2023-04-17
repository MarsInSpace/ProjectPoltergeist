//using System.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class VisitorLogic : MonoBehaviour
{
    float ReactDistance = 3f;

    public UnityEvent onFlightReaction;

    public void OnGlassDestroyed(Collision collisionInfo) {
        float distanceToGlass = Vector3.Distance(collisionInfo.transform.position, transform.position);
        if (distanceToGlass <= ReactDistance) {
            onFlightReaction.Invoke();
            Debug.Log("Observer Responds");
        }
    }

    void Start(){

    }

    void Update(){
        
    }
}
