using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public float runningSpeedIncrement = 3f;
    public float jumpForce = 20;
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
        ReloadInput();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move() {
        bool running = false;
        if (Input.GetKey(KeyCode.LeftShift)) { running = true; }
        if (running) //run
        {
            speed += runningSpeedIncrement;
            GetComponent<Animator>().SetTrigger("Running");
        }
        float x = Input.GetAxisRaw("Horizontal") * speed;
        float z = Input.GetAxisRaw("Vertical") * speed;
        x *= Time.deltaTime;
        z *= Time.deltaTime;
        transform.Translate(x, 0, z);
        if (running) speed -= runningSpeedIncrement;
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
                Debug.Log("jumping");
            if (isGrounded())
            {
                Debug.Log("jumping");
                GetComponent<Rigidbody>().AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
        }
    }
    private bool isGrounded()
    {
        int mask = LayerMask.GetMask("Default");
        float rayLength = 0.7f;
        float sphereRadius = 0.2f;
        Vector3 origin = transform.position;
        Vector3 direction = new Vector3(0, -1, 0);
        return Physics.SphereCast(origin,
                               sphereRadius,
                               direction,
                               out RaycastHit hit,
                               rayLength,
                               mask,
                               QueryTriggerInteraction.Collide)
            && hit.collider.CompareTag("Ground");
    }
    private void ShootInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animator>().SetTrigger("Shooting");
            Debug.Log("Shoot");
            Transform weapon = transform.Find("Weapon");
            weapon.GetComponent<ShootingBehaviour>().ShootBullet();
        }
    }
    private void ReloadInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Transform weapon = transform.Find("Weapon");
            weapon.GetComponent<ShootingBehaviour>().Reload();
            GetComponent<Animator>().SetTrigger("Reloading");
        }
    }
    private void CreatePortalInput()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Transform weapon = transform.Find("Weapon");
            weapon.GetComponent<ShootingBehaviour>().CreatePortal(orangePortal);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Transform weapon = transform.Find("Weapon");
            weapon.GetComponent<ShootingBehaviour>().CreatePortal(bluePortal);
        }
    }
}
