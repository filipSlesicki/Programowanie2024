using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    public void LaunchTowards(Vector3 targetPostion)
    {
        rb = GetComponent<Rigidbody>();
        Vector3 direction = (targetPostion - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    public void OnDeath()
    {
        FindAnyObjectByType<ScoreManager>().AddScore();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().ModifyHealth(-1);
            Destroy(gameObject);
        }
    }
}
