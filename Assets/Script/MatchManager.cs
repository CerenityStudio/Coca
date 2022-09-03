using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviourPunCallbacks
{
    public GameObject leaderboard;
    public Leaderboard leaderboardScript;

    private List<Leaderboard> lboard = new List<Leaderboard>();

    void ShowLeaderboard()
    {
        leaderboard.SetActive(true);

        foreach(Leaderboard lb in lboard)
        {
            Destroy(lb.gameObject);
        }
        lboard.Clear();

        leaderboardScript.gameObject.SetActive(false);

        foreach (PlayerInfo player in allPlayers)
        {

        }

    }

}
