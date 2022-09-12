using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILeaderboard : MonoBehaviour
{
    public List<RowPodium> row;
    public ScoreManager _scoreManager;

    List<MScore> Players;

    private void Update()
    {
        ShowPlayerScore();
    }

    public void ShowPlayerScore()
    {
        Players = _scoreManager.GetListPlayerDataScore();

        for (int i = 0; i < Players.Count; i++)
        {
            if (i < 3)
            {
                row[i].gameObject.SetActive(true);
                row[i].playerName.text = Players[i].PlayerName;
                row[i].score.text = Players[i].PlayerScore.ToString();
            }
        }
    }
}
