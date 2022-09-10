using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPun
{
    #region VARIABLE
    [HideInInspector]
    public int id;
    

    [Header("Info")]
    public float moveSpeed = 5f;
    public int flag;

    [Header("Components")]
    public Player photonPlayer;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator anim;
    #endregion

    public static PlayerController me;

    #region UNITY FUNCTION
    private void Awake()
    {
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        Movement();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    #endregion

    #region FUNCTION
    [PunRPC]
    public void Initialized(Player player)
    {
        id = player.ActorNumber;
        photonPlayer = player;

        if (player.IsLocal)
            me = this;
        else
            rb.isKinematic = false;
    }

    void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    [PunRPC]
    void GetFlag(int flagToGive)
    {
        flag += flagToGive;

        FlagUI.instance.UpdateFlagText(flag);
    }

    IEnumerator Spawn(Vector3 spawnPos)
    {
        yield return new WaitForSeconds(0);
        transform.position = spawnPos;
        rb.isKinematic = false;
    }
    #endregion
}
