using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleRoyalScore : MonoBehaviour
{
	public int score;
	public Text scoreText;
	public void scoreUpdate()
	{
		scoreText.text = "Wave : " + score+1;
	}

}
