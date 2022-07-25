using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessScript : MonoBehaviour
{
    [HideInInspector]
    public GameObject GameManager;
    GameManager ManagerScript;

    private GameObject GameObjectHit;

    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        ManagerScript = GameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        ShootRay();

        if(Input.GetMouseButtonUp(0) && ManagerScript.IsOverPossessable == true && ManagerScript.IsPossessed == false) {
            Debug.Log("Clicked");
            StartCoroutine(Possess());
        }
        else if(Input.GetKey(KeyCode.Space) && ManagerScript.IsPossessed == true) {
            StartCoroutine(Unpossess());
        }
    }

    void ShootRay() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
 
        if (Physics.Raycast(ray, out hit))
        {
            GameObjectHit = hit.transform.gameObject;
        }
        else
        {
            GameObjectHit = null;
        } 
    }

    IEnumerator Possess() {
        Vector3 startPosition = transform.position;
        transform.position = Vector3.Lerp(startPosition, GameObjectHit.transform.position, 1);
        ManagerScript.IsPossessed = true;

        GameObjectHit.transform.parent = transform;
        Debug.Log("IsParented");

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.enabled = !renderer.enabled;

        yield return null;
    }

    IEnumerator Unpossess() {
        ManagerScript.IsPossessed = false;

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.enabled = !renderer.enabled;

        yield return null;
    }
}
