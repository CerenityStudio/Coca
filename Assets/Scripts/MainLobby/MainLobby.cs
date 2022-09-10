using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class MainLobby : MonoBehaviourPunCallbacks, ILobbyCallbacks
{
    //SCREEN LIST
    [Header("Screen List")]
    public GameObject nickname_screen;
    public GameObject lobbyUtama;
    public GameObject roomLobby;

    //BUTTON & INPUT

    //Screen Nickname
    [Header("Nickname")]
    public TMP_InputField nickname;
    [Space(10)]
    public Button lanjutButton;

    //Screen Lobby Utama
    [Header("Lobby Utama")]
    public TMP_InputField namaRoom;
    [Space(10)]
    public Button buatRoom;
    public Button gabungRoom;
    public Button kembaliButton1;

    //Screen Room Lobby
    [Header("Room Lobby")]
    public TextMeshProUGUI playerList;
    public TextMeshProUGUI roomName;
    public Button mulaiButton;
    public Button kembaliButton2;

    private List<GameObject> roomButtons = new List<GameObject>();
    private List<RoomInfo> roomList = new List<RoomInfo>();

    /* =========================================== */

    private void Start()
    {

        //nonaktif button saat mulai
        lanjutButton.interactable = false;
        mulaiButton.interactable = false;


        //kursor aktif
        Cursor.lockState = CursorLockMode.None;

        //jika game aktif
        if (PhotonNetwork.InRoom)
        {
            //Game jadi terlihat
            PhotonNetwork.CurrentRoom.IsVisible = true;
            PhotonNetwork.CurrentRoom.IsOpen = true;
        }
    }
    void SetScreen(GameObject screen)
    {
        //nonaktif semua screen
        nickname_screen.SetActive(false);
        lobbyUtama.SetActive(false);
        roomLobby.SetActive(false);

        //aktivasi screen yang di-request
        screen.SetActive(true);
    }

    public void ButtonBuatRoom(TMP_InputField namaRoom)
    {
        LobbyManager.instance.BuatRoom(namaRoom.text);
    }

    public void ButtonGabungRoom(TMP_InputField namaRoom)
    {
        LobbyManager.instance.GabungRoom(namaRoom.text);
    }

    public void OnPlayerNameValueChanged(TMP_InputField NicknameInput)
    {
        PhotonNetwork.NickName = NicknameInput.text;

        if (NicknameInput != null)
        {
            lanjutButton.interactable = true;
        }
        else if (NicknameInput == null)
        {
            lanjutButton.interactable = false;
        }
    }
    /*
    public override void OnConnectedToMaster()
    {
        //aktivasi button ketika sudah connect ke server
        buatRoom.interactable = true;
        gabungRoom.interactable = true;
        lanjutButton.interactable = true;
        mulaiButton.interactable = true;
    }*/

    /* ===== BUTTONS EVENT ===== */

    public void ButtonLanjut()
    {
        SetScreen(lobbyUtama);
    }

    public void ButtonBack1()
    {
        SetScreen(nickname_screen);
    }

    /* ===== ROOM LOBBY ===== */

    public override void OnJoinedRoom()
    {
        //ketika masuk room pindah screen ke roomLobby
        SetScreen(roomLobby);

        //ketika player masuk room maka lobby room akan diupdate
        photonView.RPC("UpdateLobbyUI", RpcTarget.All);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdateLobbyUI();
    }

    // RPC adalah fungsi yang memperbolehkan memanggil fungsi komputer player lain
    [PunRPC]
    void UpdateLobbyUI()
    {
        //hanya host room yang bisa pencet button start
        mulaiButton.interactable = PhotonNetwork.IsMasterClient;

        //menampilkan player yang ada di lobby
        playerList.text = "";

        foreach (Player player in PhotonNetwork.PlayerList)
        {
            playerList.text += player.NickName + "\n";
        }

        //menampilkan info lobby
        roomName.text = "<b>Lobby : </b>" + PhotonNetwork.CurrentRoom.Name;
    }

    public void OnStartGameButton()
    {
        //Lobby tertutup
        PhotonNetwork.CurrentRoom.IsOpen = false;
        //Lobby disembunyikan
        PhotonNetwork.CurrentRoom.IsVisible = false;

        LobbyManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "Gameplay");
    }

    public void OnLeaveLobbyButton()
    {
        //Keluar room
        PhotonNetwork.LeaveRoom();
        //Kembali ke screen lobby utama
        SetScreen(lobbyUtama);
    }
}