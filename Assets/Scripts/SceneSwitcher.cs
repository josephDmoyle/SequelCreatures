using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public void sceneSwitcher()
    {

    }

    public void loadGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void restart()
    {

    if (Input.GetKeyDown(KeyCode.R))
    {
            Scene loadedLevel = SceneManager.GetActiveScene();
            SceneManager.LoadScene(loadedLevel.buildIndex);
    }
        SceneManager.LoadScene("MainScene");
    }

    public void backtoMenu()
    {
        SceneManager.LoadScene("Main Menu");

    }

    public void credits()
    {
        SceneManager.LoadScene("Credits");

    }
}
