using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIScriptManager : MonoBehaviour {

    [SerializeField]
    public Text showPlayerNumber;

    private int playerNumb;
    private List<Player> players = new List<Player>();

    public List<Player> Players
    {
        get
        {
            return players;
        }

        set
        {
            players = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        playerNumb = 1;
        // showPlayerNumber = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NumbOfPlayers()
    {
        if (playerNumb < 4)
        {
            playerNumb++;
        }
        else if (playerNumb == 4)
        {
            playerNumb = 1;
        }
        showPlayerNumber.text = playerNumb.ToString();
    }

    public void NewGameClicked()
    {
        PlayerPrefs.SetInt("Players", playerNumb); //Skal sætte det level man er i

        Application.LoadLevel("Main"); //Skal loadeden Scene, hvor man kan vælge flagermus
    }

    public void ExitGameClicked()
    {
        Application.Quit();
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("Highscore",0);
        PlayerPrefs.SetInt("Highscore2",0);
        PlayerPrefs.SetInt("Highscore3",0);
    }

    private void onClick()
    {

    }
}
