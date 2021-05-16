using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DurationAndScore : MonoBehaviour
{
    int chosenTimeInMinutes;
    int chosenTimeInSeconds;
    int minutesRemaining;
    int secondsRemaining;
    int startingTime;
    int currentTime;
    int timeInGame;
    int timeRemaining;
    [SerializeField] Text durationCounter; 
    void Start()
    {
        startingTime = (int)Time.time;
        chosenTimeInMinutes = PlayerPrefs.GetInt("GameDuration");
        Debug.Log("Chosen Time: " + chosenTimeInMinutes);
        Debug.Log("Starting Time: " + startingTime);
        chosenTimeInSeconds = chosenTimeInMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = (int)Time.time;
        UpdateDurationCounter();
    }

    void UpdateDurationCounter()
    {
        timeInGame = currentTime - startingTime;
        timeRemaining = chosenTimeInSeconds - timeInGame;

        if (timeRemaining <= 0)
        {
            Cursor.visible = false;
            LoadNextScene();
        }
        
        minutesRemaining = 0;
        secondsRemaining = 0;

        while (timeRemaining >= 60)
        {
            minutesRemaining++;
            timeRemaining = timeRemaining - 60;
        }

        secondsRemaining = timeRemaining;

        if (secondsRemaining <= 9)
        {
            durationCounter.text = minutesRemaining + ":0" + secondsRemaining;
        }
        else
        {
            durationCounter.text = minutesRemaining + ":" + secondsRemaining;
        }

    }

    void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        SceneManager.LoadScene(nextScene);
    }
}
