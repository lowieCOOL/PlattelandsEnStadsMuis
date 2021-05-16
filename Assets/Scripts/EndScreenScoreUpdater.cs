using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScoreUpdater : MonoBehaviour
{
    [SerializeField] Text scoreText;
    void Start()
    {
        scoreText.text = "Je score was: " + PlayerPrefs.GetInt("Score");
    }
}
