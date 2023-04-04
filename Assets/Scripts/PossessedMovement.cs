using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessedMovement : MonoBehaviour
{
    [HideInInspector]
    public GameObject GameManager;
    GameObject Player;
    GameManager ManagerScript;
    bool isThisPossessed = false;
    float maximumFloatingHeight = 3f;
    float verticalSpeed = 3f;

    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        ManagerScript = GameManager.GetComponent<GameManager>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        if(ManagerScript.IsPossessed && gameObject.transform.IsChildOf(Player.transform)){
            isThisPossessed = true;
        }
        if (isThisPossessed && !ManagerScript.IsPossessed){
            isThisPossessed = false;
            Debug.Log(isThisPossessed);
        }
    }

    void FixedUpdate()
    {
        if(isThisPossessed){
            UpAndDownMovement();
            Debug.Log(this.gameObject.transform.position.y);
        }
    }

    void UpAndDownMovement(){
        if(Input.GetKey(KeyCode.Q) && ManagerScript.IsPossessed == true && this.gameObject.transform.position.y <= maximumFloatingHeight) {
            transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.E) && ManagerScript.IsPossessed == true) {
            transform.position += Vector3.down * verticalSpeed * Time.deltaTime;
        }
    }
}
