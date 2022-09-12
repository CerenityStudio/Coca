using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPun, IPunObservable
{
    #region VARIABLE
    [HideInInspector]
    public int id;

    [Header("Info")]
    public float moveSpeed = 5f;
    public int flag;
    public Vector2 movement;

    [Header("Components")]
    public Player photonPlayer;
    public Rigidbody2D rb;
    ScoreManager _scoreManager;
    [SerializeField] private PhotonView pv;
    #endregion

    public static PlayerController me;

    #region UNITY FUNCTION
    private void Awake()
    {
        _scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();

        pv.RPC("RPC_SetPlayersData", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer.ActorNumber, PhotonNetwork.LocalPlayer.NickName, flag);
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
    }
    #endregion

    #region FUNCTION
    [PunRPC]
    public void Initialized(Player player)
    {
        id = player.ActorNumber;
        photonPlayer = player;

        GameManager.instance.players[id - 1] = this;

        if (player.IsLocal)
            me = this;
        else
            rb.isKinematic = false;
    }

    

    [PunRPC]
    void GetFlag(int flagToGive)
    {
        flag += flagToGive;

        FlagUI.instance.UpdateFlagText(flag);

        if (pv.IsMine)
            pv.RPC("RPC_SetPlayerScore", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer.ActorNumber, flag);
    }

    IEnumerator Spawn(Vector3 spawnPos)
    {
        yield return new WaitForSeconds(1f);

        transform.position = spawnPos;
        rb.isKinematic = false;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(movement);
        }
        else
        {
            movement = (Vector2)stream.ReceiveNext();
        }
    }
    #endregion

    [PunRPC]
    void RPC_SetPlayersData(int _playerId, string _playerName, int _playerScore)
    {
        _scoreManager.AddPlayerData(_playerId, _playerName, _playerScore);
    }

    [PunRPC]
    void RPC_SetPlayerScore(int _playerId, int _playerScore)
    {
        _scoreManager.SetPlayerScore(_playerId, _playerScore);
    }
}
