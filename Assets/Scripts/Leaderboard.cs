using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    //public TMP_Text playerNameText, scoreText;

    public string[] playerNames;
    public Text[] playerNameTexts;
    public int[] playerScores;
    public int scoreTotal;
    public Text[] playerScoreText;
    public Transform[] scoreOrder;

    //public void SetDetail(string name, int score)
    //{
    //    playerNameText.text = name;
    //    scoreText.text = score.ToString();
    //}
}
