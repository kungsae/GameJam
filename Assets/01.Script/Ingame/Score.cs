using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int scorePoint;
    public int topScorePoint;

    public Text printScorePoint;
    public Text printTopScorePoint;

    void Start()
    {
        topScorePoint = PlayerPrefs.GetInt("TopKill", 0);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("04.BattleFild"))
        {
            PlayerPrefs.SetInt("Kill", 0);
        }
    }

    void Update()
    {
        PlayerPrefs.SetInt("Kill", scorePoint);
        printScorePoint.text = $"Kill : {scorePoint.ToString("0")}";

        if (scorePoint > topScorePoint)
        {
            topScorePoint = scorePoint;

            PlayerPrefs.SetInt("TopKill", topScorePoint);
        }

        printTopScorePoint.text = $"TopKill : {topScorePoint.ToString("0")}";
    }
	public void scoreUpdate()
	{
		if (!GameManager.Instance.dead)
		{
			scorePoint++;
		}
	}
}
