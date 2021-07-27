using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleRoyalScore : MonoBehaviour
{
	public int score;
	public Text scoreText;
	private void Start()
	{
		score = 1;
	}
	public void scoreUpdate()
	{
		score++;
		scoreText.text = "Wave : " + (score+1);
	}

}
