using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{


    public Behaviour restartScreen;

    public void Start()
    {
       restartScreen.enabled = false;
    }


    public void restartGame()
    {
        FindObjectOfType<GameManager>().restartGame();

    }

    public void quitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }


}
