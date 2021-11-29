using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    

    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
    }


    public void ControlsMenu()
    {
        SceneManager.LoadScene("Controls");
    }
}
