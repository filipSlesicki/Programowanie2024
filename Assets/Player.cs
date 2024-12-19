using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    //Typy
    // int - liczba ca³kowita
    // float - liczba z przecinkiem
    // string - "Tekst"
    // bool - zmienna logiczna true/false

    public float velocity = 1f;
    public float rotationSpeed = 90;
    public Bullet bulletPrefab;
    public Transform shootPoint;
    public UnityEvent onShoot;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * velocity);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.up * velocity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        // FPS = 60
        //czas trfania klatki 1/60 - Time.deltaTime
        //transform.Translate(1 * Time.deltaTime,0,0);
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }

    private void Shoot()
    {
        onShoot.Invoke();
        Debug.Log("Shoot");
        Bullet bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
}
