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

   
    [SerializeField]
    private AnimationCurve jumpFallOff;
    [SerializeField] 
    private float jumpMultiplier;
    bool isJumping;

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
    private IEnumerator JumpEvent()
    {
        float timeInAir = 0.0f;
        controller.slopeLimit = 90.0f;
        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            controller.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!controller.isGrounded &&
                    controller.collisionFlags != CollisionFlags.Above);//if we hit the ceiling

        isJumping = false;
        controller.slopeLimit = 45.0f;
    }

    private void ShootInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Shoot");
            Transform weapon = transform.Find("Weapon");
            weapon.GetComponent<Shoot>().ShootBullet();
        }
    }
}
