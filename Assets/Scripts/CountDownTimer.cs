using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{

    [SerializeField]
    private float timeRemaining;

    private float scrWidth;
    private float scrHeight;
    private float timeLabelBoxWidth;
    private float timeLabelBoxHeight;

    public bool gameEnd;

    // Use this for initialization
    void Start()
    {
        gameEnd = false;
        timeRemaining = 5;
        timeLabelBoxWidth = 400;
        timeLabelBoxHeight = 100;
        scrWidth = (Screen.width / 2) - (timeLabelBoxWidth / 2);
        scrHeight = Screen.height / 10;

    }

    // Update is called once per frame
    void Update()
    {

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            gameEnd = true;
        }
    }

    void OnGUI()
    {
        GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperCenter;
        centeredStyle.fontSize = 20;

        if (timeRemaining > 0)
        {
            GUI.Label(new Rect(scrWidth, scrHeight, timeLabelBoxWidth, timeLabelBoxHeight), "Time Remaining : " + (int)timeRemaining, centeredStyle);
            Time.timeScale = 1; //Spillet kører efter normal tid
        }
        else
        {
            GUI.Label(new Rect(scrWidth, scrHeight, timeLabelBoxWidth, timeLabelBoxHeight), "Time's Up!", centeredStyle);
            Time.timeScale = 0; //Spillet er sat på pause

            GUI.Label(new Rect(scrWidth, scrHeight + 30, timeLabelBoxWidth, timeLabelBoxHeight), "Player 1, Hit A to replay, or B to go to menu", centeredStyle);

            PlayerMvmnt p1 = new PlayerMvmnt();

            Player2Mvmnt p2 = new Player2Mvmnt();

            if (p1.points > p2.points)
            {
                GUI.Label(new Rect(scrWidth, scrHeight + 60, timeLabelBoxWidth, timeLabelBoxHeight), "Player 1 Wins!", centeredStyle);

            }
            else if (p1.points < p2.points)
            {
                GUI.Label(new Rect(scrWidth, scrHeight + 60, timeLabelBoxWidth, timeLabelBoxHeight), "Player 2 Wins!", centeredStyle);

            }
            else if (p1.points == p2.points)
            {
                GUI.Label(new Rect(scrWidth, scrHeight + 60, timeLabelBoxWidth, timeLabelBoxHeight), "DRAW!", centeredStyle);

            }
            if (gameEnd == true)
            {
                if (Input.GetKey(KeyCode.Joystick1Button0))
                {
                    //Continue
                    Replay();
                }
                if (Input.GetKey(KeyCode.Joystick1Button1))
                {
                    //Back
                    BackToMenu();
                }
            }
        }


    }

    void Replay()
    {
        Application.LoadLevel(0);
    }

    void BackToMenu()
    {
        Application.LoadLevel(0);
    }
}
