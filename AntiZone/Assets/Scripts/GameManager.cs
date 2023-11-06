using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;
    public Behaviour canvas;
    public Behaviour restartScreen;
    public Transform player;

    public void endGame()
    {
        if (gameOver == false)
        {
            Debug.Log("GAME OVER");
            FindObjectOfType<audioManager>().Stop("Theme");
            FindObjectOfType<audioManager>().Play("GameOver");
            gameOver = true;
            canvas.enabled = false;
            restartScreen.enabled = true;
            Time.timeScale = 0; //Pauses the time
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reloads the scene
        Score.score = 0;
        Time.timeScale = 1; // Unpauses the time


    }
}
