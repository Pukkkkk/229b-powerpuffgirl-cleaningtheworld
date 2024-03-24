using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;


    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScoreManager.scoreCount = 0;
    }

    public void Credit()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void Back()
    {
        SceneManager.LoadScene("GameScene");
    }
}
