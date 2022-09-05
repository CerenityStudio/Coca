using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public int jumlahPlayer;

    public static LobbyManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public void BuatRoom(string namaRoom)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)jumlahPlayer;

        PhotonNetwork.CreateRoom(namaRoom, options);
    }

    public void GabungRoom(string namaRoom)
    {
        PhotonNetwork.JoinRoom(namaRoom);
    }

    //Mengubah scene menggunakan sistem photon
    [PunRPC]
    public void ChangeScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }
}