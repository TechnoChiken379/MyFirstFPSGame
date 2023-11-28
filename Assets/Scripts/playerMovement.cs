using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class playerMovement : MonoBehaviour
{
    #region variables
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float walkSpeed = 7f;
    [SerializeField] private float runSpeed = 10f;

    private Vector3 moveDirection;
    private Vector3 moveDirection2;
    private Vector3 moveDirectionX;
    private Vector3 moveDirectionZ;
    private Vector3 velocity;
    private float gravity = -9.81f;
    private float jumpheight = 4f;

    private CharacterController characterController;

    private float baseLineGravity;
    private float xMove;
    private float zMove;
    private Vector3 move;
    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float MoveZ = Input.GetAxis("Vertical");
        float MoveX = Input.GetAxis("Horizontal");

        moveDirectionZ = new Vector3(0, 0, MoveZ);
        moveDirectionX = new Vector3(MoveX, 0, 0);
        moveDirection = transform.TransformDirection(moveDirectionX + moveDirectionZ);
        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) //walk
        {
            Walk();
        }
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) //run
        {
            Run();
        }

        if (characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space)) // jump
            {
                jump();
            }
            if (moveDirection != Vector3.zero)// idle
            {
                idle();
            }
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime; // applies gravity
        characterController.Move(velocity * Time.deltaTime);
    }
    private void Walk()
    {
        moveDirection *= walkSpeed;
    }
    private void Run()
    {
        moveDirection *= runSpeed;
    }
    private void jump()
    {
        velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
    }
    private void idle()
    {

    }
}