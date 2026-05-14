using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovementScript : MonoBehaviour
{
    public float speed = 6f;
    public static bool bspeed = false;
    public float sprintSpeed = 4f;
    public float sprintSpeedBonus = 0f;
    public float jupHeight = 1.8f;
    public float grav = -9.81f;
    private Vector3 velocity;

    private CharacterController controller;

    public static bool onGround;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    // canJump = true;
    public static int airJumps = 0;
    int airJumpsLeft = 0;

    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        airJumpsLeft = airJumps;
    }

    // Update is called once per frame
    void Update()
    {


        onGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        


        if (onGround && velocity.y < 0)
        {
            airJumpsLeft = airJumps;
            velocity.y = -2f;
        }


        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
        {
            input.y += 1;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            input.y -= 1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            input.x += 1;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            input.x -= 1;
        }

        Vector3 move = transform.right * input.x + transform.forward * input.y;
        controller.Move(move * (speed + sprintSpeedBonus) * Time.deltaTime);


        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (onGround)
            {
                velocity.y = Mathf.Sqrt(jupHeight * -2f * grav);
            }
            else if (airJumpsLeft > 0)
            {
                airJumpsLeft--;
                velocity.y = Mathf.Sqrt(jupHeight * -2f * grav);
            }

        }

        velocity.y += grav * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);



        if (Keyboard.current.leftShiftKey.isPressed)
        {
            sprintSpeedBonus = sprintSpeed;
        }
        else
        {
            sprintSpeedBonus = 0;
        }


    }
}
