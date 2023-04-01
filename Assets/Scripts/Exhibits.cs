using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhibits : MonoBehaviour
{
    [HideInInspector]
    public GameObject GameManager;
    public GameManager ManagerScript;

    // [SerializeField]
    // List<GameObject> GlassChildren = new List<GameObject>();

    public delegate void ExhibitHit(Collision collisionInfo);
    public event ExhibitHit GotHit;


    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        ManagerScript = GameManager.GetComponent<GameManager>();

        // foreach(Transform child in transform) {
        //     GameObject glassChild = child.gameObject;
        //     GlassChildren.Add(glassChild);
        // }

        // Debug.Log(GlassChildren.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        GotHit?.Invoke(collisionInfo);
        // if(collisionInfo.gameObject.tag == "Possessable" && !ManagerScript.IsPossessed) {
        //     for(int i = 0; i < GlassChildren.Count; i++) {
        //         Rigidbody rigidbody = GlassChildren[i].AddComponent<Rigidbody>();
        //     }
        // }    
    }
}
