using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhibits : MonoBehaviour
{
    [HideInInspector]
    public GameObject GameManager;
    public GameManager ManagerScript;

    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        ManagerScript = GameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
