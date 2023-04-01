using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody PlayerRigidbody;

    public float Speed = 3f;
    public float RotationSpeed = 0.3f;
    private float turnY;

    void Start() {
        PlayerRigidbody = GetComponent<Rigidbody>();
        PlayerRigidbody.rotation = Quaternion.Euler(0f, -90f, 0f);
    }

    void Update() {
        
    }

    private void FixedUpdate() {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
 
        Vector3 inputMove = new Vector3(moveX * RotationSpeed, 0.0f, moveZ * Speed);
 
        Vector3 movement = transform.forward * inputMove.z;
        movement.y = PlayerRigidbody.velocity.y;
 
        PlayerRigidbody.velocity = movement;
 
        turnY += inputMove.x * Time.deltaTime;

        PlayerRigidbody.rotation = Quaternion.Euler(0.0f, turnY, 0.0f);
    }
}
