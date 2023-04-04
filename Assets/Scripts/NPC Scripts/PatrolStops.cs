using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolStops : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Guard"){
            GuardMovement script = other.GetComponent<GuardMovement>();
            script.isAtDestination = true;
        }
    }
}
