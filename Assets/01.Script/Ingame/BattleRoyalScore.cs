using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleRoyalScore : MonoBehaviour
{
    public int scorePoint;
    public int topScorePoint;

    public Text printScorePoint;
    public Text printTopScorePoint;

    void Start()
    {
        topScorePoint = PlayerPrefs.GetInt("TopScore", 0);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("04.BattleFild"))
        {
            PlayerPrefs.SetInt("Score", 1);
        }
        scorePoint = PlayerPrefs.GetInt("Score", 0);
    }

    void Update()
    {
        PlayerPrefs.SetInt("Score", scorePoint);
        printScorePoint.text = $"Wave : {scorePoint.ToString("0")}";

        if (scorePoint > topScorePoint)
        {
            topScorePoint = scorePoint;

            PlayerPrefs.SetInt("TopScore", topScorePoint);
        }

        printTopScorePoint.text = $"TopWave : {topScorePoint.ToString("0")}";
    }

    public void scoreUpdate()
    {
        scorePoint++;
    }
}
