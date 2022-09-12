using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    [Header("Players List")]
    public List<MScore> ScorePlayerList;

    public void SetPlayersData(int _playerId, string _playerName, int _playerScore)
    {
        MScore playerScore = new MScore();

        playerScore.PActorNumber = _playerId;
        playerScore.PlayerName = _playerName;
        playerScore.PlayerScore = _playerScore;

        ScorePlayerList.Add(playerScore);
    }

    public void AddPlayerData(int _playerId, string _playerName, int _playerScore)
    {
        if (!ScorePlayerList.Any(item => item.PActorNumber == _playerId)) SetPlayersData(_playerId, _playerName, _playerScore);
    }

    public void SetPlayerScore(int _playerid, int _playerScore)
    {
        var playerScore = ScorePlayerList.Find((x) => x.PActorNumber == _playerid);
        playerScore.PlayerScore = _playerScore;
    }

    public IEnumerable<MScore> GetPlayerDataScore() => ScorePlayerList.OrderByDescending(player => player.PlayerScore).ThenBy(player => player.PlayerName);
}
