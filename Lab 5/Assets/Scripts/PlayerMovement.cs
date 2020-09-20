using UnityEngine;
using System.Collections;

// The GameObject is made to bounce using the space key.
// Also the GameOject can be moved forward/backward and left/right.
// Add a Quad to the scene so this GameObject can collider with a floor.

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float gravity;

    Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;

    public Transform thingToLookFrom;



    void Start()
    {
        controller = GetComponent<CharacterController>();


        if (speed <= 0)
        {
            speed = 8.0f;

            Debug.Log("Speed not set on " + name + ". Defaulting to " + speed);
        }

        if (jumpSpeed <= 0)
        {
            jumpSpeed = 8.0f;

            Debug.Log("JumpSpeed not set on " + name + ". Defaulting to " + jumpSpeed);
        }

        if (gravity <= 0)
        {
            gravity = 20.0f;

            Debug.Log("Gravity not set on " + name + ". Defaulting to " + gravity);
        }


    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);

    }

  
}
