using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour
{

    public Transform[] plane = new Transform[4];

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        plane[0].transform.position += new Vector3(0, 0, -4);
        plane[1].transform.position += new Vector3(0, 0, -4);
        plane[2].transform.position += new Vector3(0, 0, -4);
        plane[3].transform.position += new Vector3(0, 0, -4);



        if (plane[0].transform.position.z <= -300)
        {
            plane[0].transform.position = new Vector3(12, -17.5f, 1700);
        }

        if (plane[1].transform.position.z <= -300)
        {
            plane[1].transform.position = new Vector3(12, -17.5f, 1700);
        }

        if (plane[2].transform.position.z <= -300)
        {
            plane[2].transform.position = new Vector3(12, -17.5f, 1700);
        }

        if (plane[3].transform.position.z <= -300)
        {
            plane[3].transform.position = new Vector3(12, -17.5f, 1700);
        }


    }
}
