using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    public static float scoreCount;

    void Update()
    {
        scoreText.text = "Score : " + Mathf.Round(scoreCount);
    }
}
