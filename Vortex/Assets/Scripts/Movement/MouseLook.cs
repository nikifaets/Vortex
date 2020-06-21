using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField]
    public float mouseSensitivity = 0.5f;
    public GameObject gun;
    float xRotation = 0f;
    float yRotation = 0f;

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


        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yRotation, 0), Time.deltaTime*10f);
        gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, Quaternion.Euler(xRotation, yRotation, 0), Time.deltaTime*10f);

    }
}