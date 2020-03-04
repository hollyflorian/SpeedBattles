using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float playerSprintSpeed = 15f;
    public float playerGravity = -9f;
    public float playerJump = 2f;
    public CharacterController controller;

    // GroundCheck
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if(Input.GetKey("left shift")){
            controller.Move(move * playerSprintSpeed * Time.deltaTime);
        }else{
            controller.Move(move* playerSpeed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(playerJump * -4f *playerGravity);
        }

        velocity.y += playerGravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
