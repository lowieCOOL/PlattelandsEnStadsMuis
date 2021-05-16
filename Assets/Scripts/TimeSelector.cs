using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSelector : MonoBehaviour
{
    int gameDuration;
    private void Start()
    {
        gameDuration = 1;
        Debug.Log(gameDuration);
    }
    public void GetLength(int value)
    {
        gameDuration = value + 1;
        Debug.Log(gameDuration);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("GameDuration", gameDuration);
    }
}
