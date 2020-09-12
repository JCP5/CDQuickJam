using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTravel : MonoBehaviour
{

    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
