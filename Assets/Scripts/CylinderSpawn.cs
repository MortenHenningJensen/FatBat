using UnityEngine;
using System.Collections;

public class CylinderSpawn : MonoBehaviour
{

    [SerializeField]
    Rigidbody cylinder;

    [SerializeField]
    Transform spawnPos;

    private Vector3 lookPos;

    Vector3 rndSpawnPos;


    Random rnd;

    Random cylinderAngle;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 5, 3);

    }

    // Update is called once per frame
    void Update()
    {
        rndSpawnPos = new Vector3(Random.Range(-20, 20), Random.Range(7, 7), Random.Range(60, 60));

    }

    void Spawn()
    {
        Rigidbody pFab = (Rigidbody)Instantiate(cylinder, rndSpawnPos, Quaternion.identity);

        pFab.velocity = new Vector3(0, 0, -5);
        pFab.transform.Rotate(0, 0, Random.Range(0, 360));

        Destroy(pFab.gameObject, 15);
    }
}
