using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 CameraOffset;
    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(0, Player.position.y + CameraOffset.y, Player.position.z + CameraOffset.z);
        transform.position = targetPosition;
    }
}
