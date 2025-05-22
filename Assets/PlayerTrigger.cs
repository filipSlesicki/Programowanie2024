using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour, IClickable
{
    public UnityEvent onPlayerEnter;

    public void OnClick()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            onPlayerEnter.Invoke();
        }
    }


}
