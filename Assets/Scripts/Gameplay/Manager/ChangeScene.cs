using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviourPunCallbacks
{
    public void LanjutButton()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("Loading");
    }
}
