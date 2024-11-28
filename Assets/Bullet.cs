using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * 10, ForceMode.Impulse);
        Destroy(gameObject, 3);
    }

}
