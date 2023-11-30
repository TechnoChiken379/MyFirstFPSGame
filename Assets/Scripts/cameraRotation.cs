using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    public Transform MainCharacter;
    private float xMouse;
    private float yMouse;
    private float xRotations;
    public float speed = 300f;
    
    public float defaultFOV = 90;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        xMouse = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        yMouse = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        xRotations -= yMouse;
        xRotations = Mathf.Clamp(xRotations, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotations, 0f, 0f);
        MainCharacter.Rotate(Vector3.up * xMouse);
        
        if (!Input.GetMouseButton(1)) cam.fieldOfView = (defaultFOV);
        else cam.fieldOfView = (defaultFOV * 0.60f);
    }
}
