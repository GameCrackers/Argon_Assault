﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
   
    int score;
    Text scoreText;
   // string scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void ScoreHit(int scorePerHit)
    {
        score += scorePerHit;
        scoreText.text = score.ToString();
    }

}
