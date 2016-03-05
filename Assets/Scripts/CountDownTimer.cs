using UnityEngine;
using System.Collections;

public class CountDownTimer : MonoBehaviour {

    [SerializeField]
    private float timeRemaining;

    private float scrWidth;
    private float scrHeight;
    private float timeLabelBoxWidth;
    private float timeLabelBoxHeight;

    // Use this for initialization
    void Start () {
        timeRemaining = 10;
        timeLabelBoxWidth = 200;
        timeLabelBoxHeight = 100;
        scrWidth = (Screen.width / 2) - (timeLabelBoxWidth / 2);
        scrHeight = Screen.height / 10;
    }
	
	// Update is called once per frame
	void Update () {
        timeRemaining -= Time.deltaTime;

	}

    void OnGUI()
    {
        GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperCenter;

        if (timeRemaining > 0)
        {
            GUI.Label(new Rect(scrWidth, scrHeight, timeLabelBoxWidth, timeLabelBoxHeight), "Time Remaining : " + (int)timeRemaining, centeredStyle);
            Time.timeScale = 1; //Spillet kører efter normal tid
        }
        else
        {
            GUI.Label(new Rect(scrWidth, scrHeight, timeLabelBoxWidth, timeLabelBoxHeight), "Time's Up!", centeredStyle);
            Time.timeScale = 0; //Spillet er sat på pause
        }
    }
}
