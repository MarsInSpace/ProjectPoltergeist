using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessedMovement : MonoBehaviour
{
    [HideInInspector]
    public GameObject GameManager;
    GameManager ManagerScript;

    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        ManagerScript = GameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ManagerScript.IsPossessed == true) {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }
}
