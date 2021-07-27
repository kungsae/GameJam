using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    
    void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    public void GameIsOver()
    {
        gameOverPanel.SetActive(true);
    }
}
