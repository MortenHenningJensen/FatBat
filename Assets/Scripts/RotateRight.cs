using UnityEngine;
using System.Collections;

public class RotateRight : MonoBehaviour
{
   
    private Vector3 tilt;
    float tiltRotation = 65.0f;
    float direction;
    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      

    }
    void Update()
    {
        
        float p1Right = Input.GetAxisRaw("Right_P1");

        if (p1Right >= 0.2 || Input.GetKey(KeyCode.Joystick1Button5))
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
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(tilt), Time.deltaTime * speed);
    }

}

