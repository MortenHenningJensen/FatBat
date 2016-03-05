﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player2Mvmnt : MonoBehaviour
{

    public Rigidbody myRigidbody;
    //public Rigidbody rightWing;
    // public Rigidbody leftWing;
    private int chargeCD;
    private bool leftRdy = false;
    private bool rightRdy = false;
    private bool wingUpLeft = false;
    private float friction;
    private bool wingUpRight = false;
    [SerializeField]
    private float movementSpeed;

    public Transform[] colliders = new Transform[3];

    private int points;

    public Camera cam;

    public Text txtPoints;


    // Use this for initialization
    void Start()
    {
        movementSpeed = 20;
        friction = 0.95f;
        chargeCD = 10;
        myRigidbody.mass = 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float p2Left = Input.GetAxisRaw("Left_P2");
        float p2Right = Input.GetAxisRaw("Right_P2");

        //float translate = movementSpeed * Time.deltaTime;

        //transform.Rotate(0, 0, Input.GetAxis("Left_P1"));
        //transform.Rotate(0, 0, -(Input.GetAxis("Right_P1")));

        txtPoints.text = "Player 2 Points: " + points.ToString();
//        float horizontal = Input.GetAxisRaw("Horizontal");
//        float vertical = Input.GetAxisRaw("Vertical");

        if (p2Left <= -0.2)
        {

            leftRdy = true;
            transform.Rotate(0, 0, Input.GetAxis("Left_P2"));
            //transform.position += transform.up * Time.deltaTime * movementSpeed * 1.5f;              

        }
        if (p2Left >= 0.2)
        {
            if (leftRdy == true)
            {
                myRigidbody.AddRelativeForce(Vector3.up * movementSpeed);
                //transform.position += transform.up * Time.deltaTime * movementSpeed * 1.5f;

                leftRdy = false;
            }
            else
            {

            }
        }
        if (p2Right <= -0.2)
        {

            rightRdy = true;
            transform.Rotate(0, 0, -(Input.GetAxis("Right_P2")));
            //transform.position += transform.up * Time.deltaTime * movementSpeed * 1.5f;
        }
        if (p2Right >= 0.2)
        {
            if (rightRdy == true)
            {
                myRigidbody.AddRelativeForce(Vector3.up * movementSpeed);

                //transform.position += transform.up * Time.deltaTime * movementSpeed * 1.5f;
                rightRdy = false;
            }
            else
            {

            }
        }

        if (Input.GetKey(KeyCode.Joystick2Button5))
        {
            if (chargeCD >= 10)
            {
                myRigidbody.AddRelativeForce(Vector3.up * movementSpeed * 2);
                chargeCD = 0;
            }
            else
            {

            }
        }
        chargeCD++;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
            myRigidbody.mass += 0.1f;
            transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            points += 10;
            cam.transform.position += new Vector3(0, 0, -0.5f);

            colliders[0].transform.position += new Vector3(-0.5f, -0.5f, 0);
            colliders[1].transform.position += new Vector3(0.5f, 0.5f, 0);
            colliders[2].transform.position += new Vector3(0.5f, 0.5f, 0);

            colliders[0].transform.localScale += new Vector3(0, 5, 0);
            colliders[1].transform.localScale += new Vector3(0, 5, 0);
            colliders[2].transform.localScale += new Vector3(5, 0, 0);


        }
        if (other.gameObject.CompareTag("DmgPlayer"))
        {
            Destroy(other.gameObject);
            transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
            points -= 10;
            cam.transform.position -= new Vector3(0, 0, -0.5f);

            colliders[0].transform.position -= new Vector3(0.5f, 0.5f, 0);
            colliders[1].transform.position -= new Vector3(0.5f, 0.5f, 0);
            colliders[2].transform.position -= new Vector3(0.5f, 0.5f, 0);
        }
    }

    void OnCollision(Collision other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            this.points -= 10;
        }
    }
}

