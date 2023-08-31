using UnityEngine;

public class CameraFollow360 : MonoBehaviour
{
    public Transform player;
    public float distance = 10;
    public float height = 5;
    public Vector3 lookOffset = new(0, 1, 0);
    private const float CameraSpeed = 100;
    private const float RotSpeed = 100;

    private void FixedUpdate()
    {
        if (player)
        {
            var lookPosition = player.position + lookOffset;
            var relativePos = lookPosition - transform.position;
            var rot = Quaternion.LookRotation(relativePos);

            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * RotSpeed * 0.1f);

            var targetPos = player.transform.position + player.transform.up * height -
                            player.transform.forward * distance;

            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * CameraSpeed * 0.1f);
        }
    }
}