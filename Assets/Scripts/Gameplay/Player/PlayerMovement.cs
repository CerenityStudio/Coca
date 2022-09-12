using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public PlayerController playerControl;
    
    [Header("Player")]
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        playerControl.movement.x = Input.GetAxisRaw("Horizontal");
        playerControl.movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", playerControl.movement.x);
        anim.SetFloat("Vertical", playerControl.movement.y);
        anim.SetFloat("Speed", playerControl.movement.sqrMagnitude);

        playerControl.rb.velocity = playerControl.movement.normalized * playerControl.moveSpeed;
    }
}
