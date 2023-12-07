using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class playerMovement : MonoBehaviour
{
    #region variables
    // Movement speeds for different states
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float crawlSpeed = 1.80f;

    // Movement vectors and variables
    private Vector3 moveDirection;
    private Vector3 moveDirection2;
    private Vector3 moveDirectionX;
    private Vector3 moveDirectionZ;
    private Vector3 velocity;
    private float gravity = -30f;
    private float jumpheight = 2f;
    private float airSpeed = 0.78f;

    // Jump-related variables
    private float jumpAmount;
    private float jumpTimer = 0.5f;

    private CharacterController characterController;

    // Variables for baseline gravity and movement along X and Z axes
    private float baseLineGravity;
    private float xMove;
    private float zMove;
    private Vector3 move;

    // Variables for handling player scale changes
    private float ogScale;
    private float normaleScale;
    private float newScale;

    public int health = 100;


    public PhysicMaterial slidingPhysicMaterial;
    public PhysicMaterial defaultPhysicMaterial;

    private Rigidbody rb;
    public GameObject Body;
    public GameObject MainCam;

    #endregion

    void Start()
    {
        // Initialization
        characterController = GetComponent<CharacterController>(); // Gets CharacterController
        ogScale = characterController.height;
        normaleScale = ogScale;
        newScale = normaleScale / 2;
    }

    void Update()
    {
        Move(); // Handles player movement
        jumpTimer += Time.deltaTime; // Updates jumpTimer
    }

    private void Move()
    {
        // Handling gravity when the player is grounded
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Getting input for movement along Z and X axes
        float MoveZ = Input.GetAxis("Vertical"); // Input for MoveDirection along Axis Z
        float MoveX = Input.GetAxis("Horizontal"); // Input for MoveDirection along Axis X

        // Creating vectors for movement along Z and X axes
        moveDirectionZ = new Vector3(0, 0, MoveZ);
        moveDirectionX = new Vector3(MoveX, 0, 0);

        // Transforming move directions based on the player's orientation
        moveDirection = transform.TransformDirection(moveDirectionX + moveDirectionZ);

        // Handling walking, running, and crawling based on user input
        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) Walk();
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) Run();

        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftControl))
        {
            Walk();
            //rb.freezeRotation = false;
            GetComponent<Collider>().material = defaultPhysicMaterial;
        }
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftControl))
        {
            Crawl();
            GetComponent<Collider>().material = slidingPhysicMaterial;
        }

        // Scaling the player based on whether LeftControl is pressed or not
        if (Input.GetKey(KeyCode.LeftControl))
        {
            ogScale = newScale;
            characterController.height = newScale;
            Body.transform.localScale = new Vector3(1, 0.5f, 1);
            MainCam.transform.localPosition = new Vector3(0, 0.4f, 0);
        }
        else if (!Input.GetKey(KeyCode.LeftControl))
        {
            ogScale = normaleScale;
            characterController.height = normaleScale;
            Body.transform.localScale = new Vector3(1, 1, 1);
            MainCam.transform.localPosition = new Vector3(0, 0.8f, 0);
        }

        // Handling double jump mechanics
        if (Input.GetKey(KeyCode.Space) && jumpTimer >= 0.5 && jumpAmount > 0)
        {
            Jump();
            jumpAmount -= 1;
            jumpTimer = 0f;
        }

        // Handling movement and idle state when the player is grounded
        if (characterController.isGrounded)
        {
            if (moveDirection != Vector3.zero)
            {
                Idle();
            }
            jumpAmount = 1;
        }
        else
        {
            moveDirection *= airSpeed;
        }

        // Moving the character controller and applying gravity
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.rigidbody)
        {
            health -= 10;
        }
    }

    // Movement methods for different states
    private void Walk()
    {
        moveDirection *= walkSpeed;
    }

    private void Run()
    {
        moveDirection *= runSpeed;
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
    }

    private void Idle()
    {
        // Placeholder for idle state actions (if any)
    }

    public void Crawl()
    {
        //rb.freezeRotation = true;
        moveDirection *= crawlSpeed;
    }
}
