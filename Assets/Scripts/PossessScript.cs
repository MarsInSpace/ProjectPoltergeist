using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessScript : MonoBehaviour
{
    [HideInInspector]
    public GameObject GameManager;
    GameManager ManagerScript;

    private GameObject GameObjectHit;
    RaycastHit hit;

    GameObject PossessedObject;
    
    [HideInInspector]
    public Rigidbody PossessedRigidbody;

    [SerializeField]
    float throwVelocity = 10f;

    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        ManagerScript = GameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        ShootRay();

        if(Input.GetMouseButtonUp(0) && ManagerScript.IsOverPossessable == true && ManagerScript.IsPossessed == false && PossessedObject == null) {
            Debug.Log("Clicked");
            StartCoroutine(Possess());
        }
        else if(Input.GetKey(KeyCode.Space) && ManagerScript.IsPossessed == true) {
            StartCoroutine(Unpossess());
        }
        else if(Input.GetMouseButton(0) && ManagerScript.IsPossessed == true) {
            ThrowPossessable(hit);
        }
    }

    void ShootRay() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
        if (Physics.Raycast(ray, out hit))
        {
            GameObjectHit = hit.transform.gameObject;
        }
        else
        {
            GameObjectHit = null;
        } 
    }

    void ThrowPossessable(RaycastHit hitpoint) {
        PossessedRigidbody.velocity = (hitpoint.point - transform.position).normalized * throwVelocity;
        PossessedRigidbody.rotation = Quaternion.LookRotation(PossessedRigidbody.velocity);

        StartCoroutine(Unpossess());
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Walkthroughable" && !ManagerScript.IsPossessed) {
            Physics.IgnoreCollision(collisionInfo.collider, GetComponent<Collider>());
        }
    }

    IEnumerator Possess() {
        Vector3 startPosition = transform.position;
        transform.position = Vector3.Lerp(startPosition, GameObjectHit.transform.position, 1);
        ManagerScript.IsPossessed = true;

        GameObjectHit.transform.parent = transform;
        PossessedObject = GameObjectHit;
        PossessedRigidbody = GameObjectHit.GetComponent<Rigidbody>();
        Debug.Log("IsParented");

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.enabled = !renderer.enabled;

        yield return null;
    }

    IEnumerator Unpossess() {
        ManagerScript.IsPossessed = false;
        PossessedObject = null;

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.enabled = !renderer.enabled;

        yield return null;
    }
}
