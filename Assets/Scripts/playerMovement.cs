using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

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
    private float gravity = -45f;
    private float jumpheight = 3.5f;
    private float airSpeed = 1.27f;

    // Jump-related variables
    public float jumpAmount;
    public float jumpTimer = 0.65f;
    private float maxJumpTimer = 0.65f;

    private CharacterController characterController;

    // Variables for handling player scale changes
    private float ogScale;
    private float normaleScale;
    private float newScale;

    public static int minHealthPointsAmount = 0;
    public static int healthPointsAmount = 100;
    public static int currentAmountHealthPoints;
    public static float healthTimer;
    private float maxHealthTimer = 1f;

    private Rigidbody rb;
    public GameObject Body;
    public GameObject MainCam;

    private BoxCollider boxCollider;
    public GameObject Enemy;

    private EnemyMovement damageAmount;

    private bool wallJump;
    #endregion

    void Start()
    {
        // Initialization
        currentAmountHealthPoints = healthPointsAmount;
        characterController = GetComponent<CharacterController>(); // Gets CharacterController
        ogScale = characterController.height;
        normaleScale = ogScale;
        newScale = normaleScale / 2;
        boxCollider = Enemy.GetComponent<BoxCollider>();
    }

    void Update()
    {
        DeathScene();
        Move(); // Handles player movement
        jumpTimer += Time.deltaTime; // Updates jumpTimer
        healthTimer += Time.deltaTime;
    }

    private void Move()
    {
        // Handling gravity when the player is grounded
        if (Input.GetKey(KeyCode.RightAlt))
        {
            healthPointsAmount = currentAmountHealthPoints;
            SceneManager.LoadScene("MainMenu");
        }

        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
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
        }
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftControl))
        {
            Crawl();
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
        if (Input.GetKey(KeyCode.Space) && jumpTimer >= maxJumpTimer && jumpAmount > 0)
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

    public void DeathScene()
    {
        if (healthPointsAmount <= minHealthPointsAmount)
        {
            SceneManager.LoadScene("DeathScene");
            healthPointsAmount = currentAmountHealthPoints;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        {
            if (hit.gameObject.tag == "WallJump")
            {
                wallJump = true;
            }
            else if (hit.gameObject.tag == "Untagged")
            {
                wallJump = false;
            }

            if (hit.gameObject.tag == "MILK")
            {
                SceneManager.LoadScene("WinningScene");
            }

            if (hit.gameObject.tag == "NPC" && healthTimer >= maxHealthTimer)
            {
                healthPointsAmount -= EnemyMovement.damageAmount;
                healthTimer = 0f;
            }

            if (wallJump == true)
            {
                jumpAmount = 2;
                maxJumpTimer = 0.2f;
                if (characterController.isGrounded)
                {
                    jumpTimer = 0.2f;
                }
                else
                {
                    jumpTimer = 0.1f;
                }
            }
            else if (wallJump == false)
            {
                maxJumpTimer = 0.5f;
            }
        }
    }
}
