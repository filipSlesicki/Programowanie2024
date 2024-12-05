using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * 10, ForceMode.Impulse);
     
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        Health hitHealth = other.GetComponent<Health>();
        if (hitHealth != null)
        {
            hitHealth.ModifyHealth(-1);
        }

        if(other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.TryGetComponent(out Health health))
        //{
        //    health.ModifyHealth(-1);
        //}

        Health hitHealth = collision.gameObject.GetComponent<Health>();
        if (hitHealth != null)
        {
            hitHealth.ModifyHealth(-1);
        }

        Destroy(gameObject);
    }
}
