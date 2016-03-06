using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour
{
    CountDownTimer cdt = new CountDownTimer();
    public Transform[] plane = new Transform[4];

    [SerializeField]
    private float speedPlane;

    // Use this for initialization
    void Start()
    {
        speedPlane = -0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (cdt.gameEnd == false)
        {
            plane[0].transform.position += new Vector3(0, 0, speedPlane);
            plane[1].transform.position += new Vector3(0, 0, speedPlane);
            plane[2].transform.position += new Vector3(0, 0, speedPlane);
            plane[3].transform.position += new Vector3(0, 0, speedPlane);
        }
        else
        {
            plane[0].transform.position = new Vector3(0, 0, 0);
            plane[1].transform.position = new Vector3(0, 0, 0);
            plane[2].transform.position = new Vector3(0, 0, 0);
            plane[3].transform.position = new Vector3(0, 0, 0);
        }



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
