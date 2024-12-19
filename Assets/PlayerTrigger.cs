using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    public UnityEvent onPlayerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            onPlayerEnter.Invoke();
        }
    }
}
