using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour {

    public Canvas endScreen;
    public Button restartGame;
    public Button menu;


    // Use this for initialization
    void Start () {

        restartGame = restartGame.GetComponent<Button>();
        menu = menu.GetComponent<Button>();

        menu.enabled = true;
        restartGame.enabled = true;

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.H))
        {
            MenuGame();
        }
	}


    public void MenuGame()
    {
        Debug.Log("Menu");
        Application.LoadLevel(0);
    }

    public void RestartGame()
    {
        Debug.Log("Restart");
        Application.Quit();
    }

}
