using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnThings : MonoBehaviour {

    [SerializeField]
    Rigidbody kittyKat;

    [SerializeField]
    Transform spawnPos;

    private Vector3 lookPos;

    Vector3 rndSpawnPos;

    Random rnd;

    private float timer;
    private bool timeStarted = false;
    public Text txtTimer;

    // Use this for initialization
    void Start () {
        // Spawn();
        // rndSpawnPos = new Vector3(Random.Range(-10, 10), Random.Range(5, 20), Random.Range(30, 50));
        InvokeRepeating("Spawn", 1, 2);
        timer = 120;
        timeStarted = true;
    }

    // Update is called once per frame
    void Update () {
        rndSpawnPos = new Vector3(Random.Range(-20, 20), Random.Range(-12, 6), Random.Range(30, 70));
        // Spawn();
        if (timeStarted == true)
        {
            timer -= Time.deltaTime;
        }

    }

    void Spawn()
    {
        Rigidbody pFab = (Rigidbody)Instantiate(kittyKat, rndSpawnPos, Quaternion.identity);

        pFab.velocity = Quaternion.Euler(lookPos.x, lookPos.y, 0) * (spawnPos.forward * 5);

        Destroy(pFab.gameObject, 10);
    }

    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        txtTimer.text = niceTime;
    }
}
