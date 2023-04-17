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
            StartCoroutine(Throw(hit));
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

        Destroy(PossessedRigidbody);

        Camera mainCamera = GetComponentInChildren<Camera>();
        mainCamera.transform.parent = PossessedObject.transform;

        ChangeComponentStatus();

        yield return null;
    }

    IEnumerator Unpossess() {
        Camera mainCamera = PossessedObject.GetComponentInChildren<Camera>();
        mainCamera.transform.parent = transform;

        PossessedObject.AddComponent<Rigidbody>();

        Transform possessedChild = transform.GetChild(0);
        possessedChild.transform.parent = null;

        ManagerScript.IsPossessed = false;
        PossessedObject = null;

        ChangeComponentStatus();

        yield return null;
    }

    IEnumerator Throw(RaycastHit hitpoint) {
        Camera mainCamera = PossessedObject.GetComponentInChildren<Camera>();
        mainCamera.transform.parent = transform;

        PossessedObject.AddComponent<Rigidbody>();
        PossessedRigidbody = PossessedObject.GetComponent<Rigidbody>();

        Transform possessedChild = transform.GetChild(0);
        possessedChild.transform.parent = null;

        ManagerScript.IsPossessed = false;
        PossessedObject = null;

        ChangeComponentStatus();

        PossessedRigidbody.velocity = (hitpoint.point - transform.position).normalized * throwVelocity;
        PossessedRigidbody.rotation = Quaternion.LookRotation(PossessedRigidbody.velocity);

        yield return null;
    }

    void ChangeComponentStatus(){
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.enabled = !renderer.enabled;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = !rigidbody.useGravity;

        Collider collider = GetComponent<Collider>();
        collider.enabled = !collider.enabled;
    }
}
