using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void LoadStartingScene()
    {
        int startingSceneIndex = 0;
        SceneManager.LoadScene(startingSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
