using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlassExhibits : MonoBehaviour
{
    [HideInInspector]
    public GameObject GameManager;
    public GameManager ManagerScript;

    [SerializeField]
    List<GameObject> GlassChildren = new List<GameObject>();

    public CollisionEvent onGlassDestroyed;

    //private bool IsDestroyed = false;
    

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        ManagerScript = GameManager.GetComponent<GameManager>();

        foreach(Transform child in transform) {
            GameObject glassChild = child.gameObject;
            GlassChildren.Add(glassChild);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Possessable" && !ManagerScript.IsPossessed) {
            DestroyGlass();
            Debug.Log("Recognised Possessable One");
            onGlassDestroyed.Invoke(collisionInfo);
        }
        //IsDestroyed = true;
    }

    void DestroyGlass() {
            for(int i = 0; i < GlassChildren.Count; i++) {
                Rigidbody rigidbody = GlassChildren[i].AddComponent<Rigidbody>();
            }
    }
}
