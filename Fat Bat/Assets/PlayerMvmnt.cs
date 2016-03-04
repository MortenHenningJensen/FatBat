using UnityEngine;
using System.Collections;

public class PlayerMvmnt : MonoBehaviour
{

    public Rigidbody myRigidbody;
    //public Rigidbody rightWing;
    // public Rigidbody leftWing;

    [SerializeField]
    private float movementSpeed = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 0, 5);
            transform.position += transform.up * Time.deltaTime * movementSpeed;

        }

        if (Input.GetKey(KeyCode.E))
        {

            transform.Rotate(0, 0, -5);
            transform.position += transform.up * Time.deltaTime * movementSpeed;

        }

        transform.position -= new Vector3(0, 0.1f, 0);

    }
}
