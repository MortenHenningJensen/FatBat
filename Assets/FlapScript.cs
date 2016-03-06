using UnityEngine;
using System.Collections;

public class FlapScript : MonoBehaviour
{

    private Vector3 tilt;
    float tiltRotation = 65.0f;
    int direction;
    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1;
            speed = 5;

        }
        else
        {
            direction = 0;
            speed = 20;

        }

        //Tilt of the Player in accordance with the movement.
        tilt = new Vector3(0, 0, direction * tiltRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(tilt), Time.deltaTime * speed);
    }
}