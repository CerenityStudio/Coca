using UnityEngine;
using Photon.Pun;

public enum PickupType
{
    FlagA,
    FlagB,
    FlagC
}

public class Pickups : MonoBehaviourPun
{
    public PickupType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (type == PickupType.FlagA)
            {
                player.photonView.RPC("GetFlag", player.photonPlayer, 10);
            }
            else if (type == PickupType.FlagB)
            {
                player.photonView.RPC("GetFlag", player.photonPlayer, 20);
            }
            else if (type == PickupType.FlagC)
            {
                player.photonView.RPC("GetFlag", player.photonPlayer, 50);
            }
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
