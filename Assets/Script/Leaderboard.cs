using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public TMP_Text playerNameText, scoreText;

    public void SetDetail(string name, int score)
    {
        playerNameText.text = name;
        scoreText.text = score.ToString();
    }
}
