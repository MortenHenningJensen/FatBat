using UnityEngine;
using System.Collections;

public class SideWalls : MonoBehaviour {

    [SerializeField]
    GameObject topWall;
    [SerializeField]
    GameObject leftWall;
    [SerializeField]
    GameObject rightWall;

    private float posX;
    private float posY;

    // Use this for initialization
    void Start ()
    {
        posX = Screen.width - Screen.width;
        posY = Screen.height + 20;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
