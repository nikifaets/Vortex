using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public float jumpForce = 2;
    public float raycastDistance = 1.1f;

    public GameObject orangePortal;
    public GameObject bluePortal;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        CreatePortalInput();
        ShootInput();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move() {
        float x = Input.GetAxisRaw("Horizontal") * speed;
        float z = Input.GetAxisRaw("Vertical") * speed;
        x *= Time.deltaTime;
        z *= Time.deltaTime;
        transform.Translate(x, 0, z);
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded())
            {
                GetComponent<Rigidbody>().AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
        }
    }
    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance);
    }
    private void ShootInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Shoot");
            Transform weapon = transform.Find("Weapon");
            weapon.GetComponent<ShootingBehaviour>().ShootBullet();
        }
    }
    private void CreatePortalInput()
    {
        if (Input.GetKeyDown("r"))
        {
            Transform weapon = transform.Find("Weapon");
            weapon.GetComponent<ShootingBehaviour>().CreatePortal(orangePortal);
        }
        if (Input.GetKeyDown("t"))
        {
            Transform weapon = transform.Find("Weapon");
            weapon.GetComponent<ShootingBehaviour>().CreatePortal(bluePortal);
        }
    }
}
