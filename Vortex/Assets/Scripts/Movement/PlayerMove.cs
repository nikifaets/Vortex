using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField]
    private float speed = 6.0f;
    [SerializeField]
    private float jumpHeight = 3.0f;
    [SerializeField]
    private float gravity = -20f;

   

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        Move();
    }
    private void Move()
    {
        if(controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        JumpInput();
        ShootInput();

    }

    private void JumpInput()
    {
        if (Input.GetButtonDown("Jump") && controller.isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
       }
    }
    private void ShootInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Transform weapon = transform.Find("Weapon");
            weapon.GetComponent<Shoot>().ShootBullet();
        }
    }
}
