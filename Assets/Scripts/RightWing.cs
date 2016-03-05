using UnityEngine;
using System.Collections;

public class RightWing : MonoBehaviour {

    public Rigidbody myRigidbody;

    [SerializeField]
    private float movementSpeed = 10;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Q))
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        }

    }
}
