using UnityEngine;
using System.Collections;

public class SpawnThings : MonoBehaviour {

    [SerializeField]
    Rigidbody kittyKat;

    [SerializeField]
    Transform spawnPos;

    private Vector3 lookPos;

    Vector3 rndSpawnPos;

    Random rnd;

    // Use this for initialization
    void Start () {
        // Spawn();
        // rndSpawnPos = new Vector3(Random.Range(-10, 10), Random.Range(5, 20), Random.Range(30, 50));
        InvokeRepeating("Spawn", 1, 2);

    }

    // Update is called once per frame
    void Update () {
        rndSpawnPos = new Vector3(Random.Range(-20, 20), Random.Range(-12, 6), Random.Range(30, 70));
       // Spawn();

    }

    void Spawn()
    {
        Rigidbody pFab = (Rigidbody)Instantiate(kittyKat, rndSpawnPos, Quaternion.identity);

        pFab.velocity = Quaternion.Euler(lookPos.x, lookPos.y, 0) * (spawnPos.forward * 5);

        Destroy(pFab.gameObject, 10);
    }
}
