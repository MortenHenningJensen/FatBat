using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player2Mvmnt : MonoBehaviour
{

    public Rigidbody myRigidbody;
    //public Rigidbody rightWing;
    // public Rigidbody leftWing;
    private int chargeCD = 10;
    [SerializeField]
    private float movementSpeed = 10;

    public Transform[] colliders = new Transform[3];

    private int points;

    public Camera cam;

    public Text txtPoints;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        txtPoints.text = "Player 2 Points: " + points.ToString();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.Joystick2Button5))
        {
            transform.Rotate(0, 0, 5);
            transform.position += transform.up * Time.deltaTime * movementSpeed;

        }

        if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.Joystick2Button4))
        {

            transform.Rotate(0, 0, -5);
            transform.position += transform.up * Time.deltaTime * movementSpeed;

        }

        transform.position -= new Vector3(0, 0.1f, 0);

        if (Input.GetKey(KeyCode.O) || Input.GetKey(KeyCode.Joystick2Button0))
        {
            if (chargeCD >= 10)
            {
                transform.position += transform.up * Time.deltaTime * 100;
                chargeCD = 0;
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
            Destroy(other.gameObject);
            transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            points += 10;
            cam.transform.position += new Vector3(0, 0, -1);

            colliders[0].transform.position += new Vector3(-1, -1, 0);
            colliders[1].transform.position += new Vector3(1, 1, 0);
            colliders[2].transform.position += new Vector3(1, 1, 0);

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

        if (other.gameObject.CompareTag("Border"))
        {
            this.points -= 10;
        }

    }
}
