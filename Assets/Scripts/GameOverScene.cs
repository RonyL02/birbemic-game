using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{
    public Text gameOverText;
    public Text score;

    public Text record;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        record.text += " " + PlayerPrefs.GetInt("score").ToString();

        if (FmsScript.won)
        {
            gameOverText.text = "You won!";
            score.text += " " + FmsScript.score.ToString();
        }
        else
        {
            score.text = "";
            gameOverText.text = "Game Over!";
        }
    }
    public void StartGame()
    {
        FmsScript.score = 0;
        SceneManager.LoadSceneAsync("birbemic-game");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync("StartScene");

    }
}
