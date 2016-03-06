using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player2Mvmnt : MonoBehaviour
{

    public Rigidbody myRigidbody2;
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
        myRigidbody2.mass = 0.1f;
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
                myRigidbody2.AddRelativeForce(Vector3.up * movementSpeed);
                //transform.position += transform.up * Time.deltaTime * movementSpeed * 1.5f;
                flap1.clip = flaps[Random.Range(0, flaps.Length)];
                flap1.pitch = Random.Range(0.95f, 1.1f);
                flap1.Play();

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
                myRigidbody2.AddRelativeForce(Vector3.up * movementSpeed);
                flap2.clip = flaps[Random.Range(0, flaps.Length)];
                flap2.pitch = Random.Range(0.95f, 1.1f);
                flap2.Play();

                //transform.position += transform.up * Time.deltaTime * movementSpeed * 1.5f;
                rightRdy = false;
            }
            else
            {

            }
        }

        if (Input.GetKey(KeyCode.Joystick2Button5) || Input.GetKey(KeyCode.K))
        {
            if (chargeCD >= 10)
            {
                myRigidbody2.AddRelativeForce(Vector3.up * movementSpeed * powerForce);
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
            powerForce += 0.5f;
            Destroy(other.gameObject);
            myRigidbody2.mass += 0.1f;
            transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            points += 10;
            pickup.pitch = Random.Range(0.90f, 1.1f);
            pickup.Play();
            //cam.transform.position += new Vector3(0, 0, -0.5f);
        }
        if (other.gameObject.CompareTag("DmgPlayer"))
        {
            if (points > 0)
            {
                powerForce -= 0.5f;
                myRigidbody2.mass -= 0.1f;
                Destroy(other.gameObject);

                points -= 10;
                badPickup.Play();
                //cam.transform.position -= new Vector3(0, 0, -0.5f);
                transform.localScale -= new Vector3(0.2f, 0.2f, 0);
            }
            else
            {
                points = 0;
            }
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

