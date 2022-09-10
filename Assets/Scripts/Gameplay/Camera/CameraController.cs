using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Update()
    {
        if (PlayerController.me != null)
        {
            Vector3 targetPos = PlayerController.me.transform.position;
            targetPos.z = -10;
            transform.position = targetPos;
        }
    }
}
