using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    #region Controls
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public float rotateSpeed = 4.0f;
    #endregion

    public CharacterController controller;
    public CharacterController rightWing;
    public CharacterController leftWing;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // is the controller on the ground?
        //  if (controller.isGrounded)
        //   {
        //Feed moveDirection with input.
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);

        //Multiply it by speed.
        moveDirection *= speed;
        //Jumping
        if (Input.GetKey(KeyCode.Q))
        {
            moveDirection.y = jumpSpeed;

            //Applying gravity to the controller
            moveDirection.y -= gravity * Time.deltaTime;
            //Making the character move
            rightWing.Move(moveDirection * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.E))
        {
            moveDirection.y = jumpSpeed;

            //Applying gravity to the controller
            moveDirection.y -= gravity * Time.deltaTime;
            //Making the character move
            leftWing.Move(moveDirection * Time.deltaTime);

        }

        //   }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);

    }
}
