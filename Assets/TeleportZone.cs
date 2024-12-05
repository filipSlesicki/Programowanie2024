using UnityEngine;

public class TeleportZone : MonoBehaviour
{
    public bool horizontal;
    public Transform teleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Vector3 targetPositon = teleportTarget.position;
            if(horizontal)
            {
                targetPositon.y = other.transform.position.y;
            }
            else
            {
                targetPositon.x = other.transform.position.x;
            }

            other.transform.position = targetPositon;
        }
    }
}
