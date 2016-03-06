using UnityEngine;
using System.Collections;

public class PauseStartTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(MyMethod());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator MyMethod()
    {
        Debug.Log("Before Waiting 2 seconds");
        yield return new WaitForSeconds(2);
        Debug.Log("After Waiting 2 Seconds");
    }

}
