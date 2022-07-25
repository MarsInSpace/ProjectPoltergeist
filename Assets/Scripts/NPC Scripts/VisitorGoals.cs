using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorGoals : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Visitor"){
            VisitorMovement script = other.GetComponent<VisitorMovement>();
            script.isAtDestination = true;
        }
    }
}
