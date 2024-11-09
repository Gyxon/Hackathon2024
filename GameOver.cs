using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastLevel"));
    }

    public void changeToScene(string thisScene)
    {
        SceneManager.LoadScene(thisScene);
    }
}
