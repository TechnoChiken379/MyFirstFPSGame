using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float currentSpeed;
    public float walkingSpeed = 10f;
    public float runningSpeed = 15;

    private float moveX;
    private float moveZ;

    public CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
    }
}
