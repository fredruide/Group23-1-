using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;
using System;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public Int64 playerScore;
    
    private TextMeshProUGUI ScoreTMP;

    private void Awake()
    {
        ScoreTMP = GetComponent<TextMeshProUGUI>();
        PrintScore();
    }

    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        PrintScore();
    }

    private void PrintScore()
    {
        ScoreTMP.text = "Score: " + playerScore;
    }
}
