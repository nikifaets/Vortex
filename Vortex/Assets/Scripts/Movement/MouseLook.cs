using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField]
    public float mouseSensitivity = 20f;
    public GameObject gun;
    float xRotation = 90f;
    float yRotation = 0f;
    public Transform playerCamera;
    public Transform shootingPoint;
    float lastYPos;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()

    { 

        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        
        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, 0f, 180f);


        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, yRotation, 0), Time.deltaTime*60f);


        gun.transform.Rotate(-mouseY, 0, 0);
        playerCamera.Rotate(-mouseY, 0, 0);
        shootingPoint.Rotate(-mouseY, 0, 0);

        //if(gun.transform.rotation.x > 180f) gun.transform.rotation = Quaternion.Euler(180f, gun.transform.rotation.y, gun.transform.rotation.z);
        //if(gun.transform.rotation.x < 0f) gun.transform.rotation = Quaternion.Euler(0f, gun.transform.rotation.y, gun.transform.rotation.z);
    }
}