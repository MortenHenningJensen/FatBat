using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMvmnt : MonoBehaviour
{
    public Rigidbody myRigidbody;
    // public Rigidbody rightWing;
    // public Rigidbody leftWing;
    private int chargeCD;
    private bool leftRdy = false;
    private bool rightRdy = false;
    private bool wingUpLeft = false;
    private float friction;
    private bool wingUpRight = false;
    [SerializeField]
    private float movementSpeed;

    private float p1Left;
    private float p1Right;

    public Transform[] colliders = new Transform[3];

    public int points;

    public Camera cam;

    public Text txtPoints;

    [SerializeField]
    private float powerForce;

    public AudioSource flap1;
    public AudioSource flap2;
    public AudioSource pickup;
    public AudioSource badPickup;
    public AudioClip[] flaps;



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
        p1Left = Input.GetAxisRaw("Left_P1");
        p1Right = Input.GetAxisRaw("Right_P1");

        txtPoints.text = "Player 1 Points: " + points.ToString();

        if (p1Left <= -0.2) //Up
        {
            leftRdy = true;
            transform.Rotate(0, 0, Input.GetAxis("Left_P1"));
        }
        if (p1Left >= 0.2) //Ned
	    {
		    if (leftRdy == true)
	        {
                myRigidbody.AddRelativeForce(Vector3.up * movementSpeed);
                leftRdy = false;
                flap1.clip = flaps[Random.Range(0, flaps.Length)];
                flap1.pitch = Random.Range(0.95f, 1.1f);
                flap1.Play();
            }
	    }
        if (p1Right <= -0.2)
        {
            rightRdy = true;
            transform.Rotate(0, 0, -(Input.GetAxis("Right_P1")));
        }
        if (p1Right >= 0.2)
	    {
		    if (rightRdy == true)
	        {
                myRigidbody.AddRelativeForce(Vector3.up * movementSpeed);
                rightRdy = false;
                flap2.clip = flaps[Random.Range(0, flaps.Length)];
                flap2.pitch = Random.Range(0.95f, 1.1f);
                flap2.Play();
            }
	    }


        if (Input.GetKey(KeyCode.Joystick1Button5) ||Input.GetKey(KeyCode.D))
        {
            if (chargeCD >= 10)
            {
                myRigidbody.AddRelativeForce(Vector3.up * movementSpeed * powerForce);
                chargeCD = 0;
            }
        }
        chargeCD++;
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
            pickup.pitch = Random.Range(0.90f, 1.15f);
            pickup.Play();
        }
        if (other.gameObject.CompareTag("DmgPlayer"))
        {
            if (points > 0)
            {
            powerForce -= 0.5f;
            myRigidbody.mass -= 0.1f;
            Destroy(other.gameObject);
            badPickup.Play();

            points -= 10;
            transform.localScale -= new Vector3(0.2f, 0.2f, 0);
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
}

