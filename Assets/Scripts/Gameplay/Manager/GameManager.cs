using UnityEngine;
using Photon.Pun;
using System.Linq;

public class GameManager : MonoBehaviourPun
{
    [Header("Players")]
    public string PlayerPrefabPath;
    public Transform[] spawnPoints;

    private int playersInGame;

    public PlayerController[] players;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        players = new PlayerController[PhotonNetwork.PlayerList.Length];

        photonView.RPC("ImInGame", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void ImInGame()
    {
        playersInGame++;

        if (playersInGame == PhotonNetwork.PlayerList.Length)
        {
            SpawnPlayer();
        }
    }

    void SpawnPlayer()
    {
        GameObject playerObj = PhotonNetwork.Instantiate(PlayerPrefabPath, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);

        playerObj.GetComponent<PhotonView>().RPC("Initialized", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }
}
