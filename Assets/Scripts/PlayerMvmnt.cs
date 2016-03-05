using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMvmnt : MonoBehaviour
{
    Animator myAnimator;
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

    public int points;

    public Camera cam;

    public Text txtPoints;

    [SerializeField]
    private float powerForce;


    // Use this for initialization
    void Start()
    {
        powerForce = 2;
        movementSpeed = 20;
        friction = 0.95f;
        chargeCD = 10;
        myRigidbody.mass = 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float p1Left = Input.GetAxisRaw("Left_P1");
        float p1Right = Input.GetAxisRaw("Right_P1");
        
        //float translate = movementSpeed * Time.deltaTime;

        //transform.Rotate(0, 0, Input.GetAxis("Left_P1"));
        //transform.Rotate(0, 0, -(Input.GetAxis("Right_P1")));

        txtPoints.text = "Player 1 Points: " + points.ToString();
//        float horizontal = Input.GetAxisRaw("Horizontal");
//        float vertical = Input.GetAxisRaw("Vertical");

        if (p1Left <= -0.2)
        {

               leftRdy = true;
               transform.Rotate(0, 0, Input.GetAxis("Left_P1"));
            //transform.position += transform.up * Time.deltaTime * movementSpeed * 1.5f; 
            //myAnimator.SetFloat("LeftWing", -0.2f);

        }
        if (p1Left >= 0.2)
	    {
		    if (leftRdy == true)
	        {
                myRigidbody.AddRelativeForce(Vector3.up * movementSpeed);
                //transform.position += transform.up * Time.deltaTime * movementSpeed * 1.5f;
                myAnimator.SetFloat("LeftWing", 0.2f);
            leftRdy = false;
	        }
            else
	        {
                    
	        }
	    }
        if (p1Right <= -0.2)
        {

                rightRdy = true;
                transform.Rotate(0, 0, -(Input.GetAxis("Right_P1")));
            //transform.position += transform.up * Time.deltaTime * movementSpeed * 1.5f;
            myAnimator.SetFloat("RightWing", p1Right);
        }
        if (p1Right >= 0.2)
	    {
		    if (rightRdy == true)
	        {
                myRigidbody.AddRelativeForce(Vector3.up * movementSpeed);
                myAnimator.SetFloat("RightWing", p1Right);

                //transform.position += transform.up * Time.deltaTime * movementSpeed * 1.5f;
                rightRdy = false;
	        }
            else
	        {
                    
	        }
	    }
        //transform.Translate(new Vector3(horizontal, 0, vertical) * translate);

        //if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.Joystick1Button5))
        //{
        //    transform.Rotate(0, 0, 5);
        //    transform.position += transform.up * Time.deltaTime * movementSpeed;

        //}

        //if (Input.GetKey(KeyCode.E)  || Input.GetKey(KeyCode.Joystick1Button4))
        //{

        //    transform.Rotate(0, 0, -5);
        //    transform.position += transform.up * Time.deltaTime * movementSpeed;

        //}

        //DownwardsDraft();

        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            if (chargeCD >= 10)
            {
                myRigidbody.AddRelativeForce(Vector3.up * movementSpeed * powerForce);
                chargeCD = 0;
                myAnimator.SetFloat("RightWing", p1Right);
                myAnimator.SetFloat("LeftWing", p1Left);
            }
            else
            {
                    
            }
        }
        chargeCD++;

        // myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        // myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, vertical * movementSpeed);
        //if (Input.GetButton("Jump"))
        //{
        //    transform.position += transform.up * Time.deltaTime * movementSpeed;
        //}

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            powerForce += 0.5f;
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
            if (points > 0)
            {
            powerForce -= 0.5f;
            myRigidbody.mass -= 0.1f;
            Destroy(other.gameObject);

            points -= 10;
            cam.transform.position -= new Vector3(0, 0, -0.5f);
            transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
            colliders[0].transform.position -= new Vector3(0.5f, 0.5f, 0);
            colliders[1].transform.position -= new Vector3(0.5f, 0.5f, 0);
            colliders[2].transform.position -= new Vector3(0.5f, 0.5f, 0);
            }
            else
            {
                points = 0;
            }
        }
    }

    void OnCollision (Collision other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            this.points -= 10;
        }
    }

    void DownwardsDraft()
    {
        transform.position -= new Vector3(0, 0.05f, 0);
    }
}

