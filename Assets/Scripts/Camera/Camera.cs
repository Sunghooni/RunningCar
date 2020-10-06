using UnityEngine;

public class Camera : MonoBehaviour
{
    [Header("Source")]
    public GameObject player;
    public GameObject me;

    float dist = -3f;
    float height = 2.5f;
    float smooth = 5f;

    private void FixedUpdate()
    {
        Vector3 playerPos = player.transform.localPosition;
        Vector3 targetPos = new Vector3(playerPos.x, playerPos.y + height, playerPos.z + dist);

        me.transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smooth);
        transform.LookAt(new Vector3(playerPos.x, playerPos.y + height, playerPos.z));
    }
}