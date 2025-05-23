using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IClickable
{
    //Typy
    // int - liczba ca�kowita
    // float - liczba z przecinkiem
    // string - "Tekst"
    // bool - zmienna logiczna true/false

    public float velocity = 1f;
    public float rotationSpeed = 90;
    public Bullet bulletPrefab;
    public Transform shootPoint;
    public AudioSource shootAudio;
    public UnityEvent onShoot;
    private PauseManager pauseManager;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pauseManager = FindAnyObjectByType<PauseManager>();
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
        if(pauseManager.isGamePaused)
        {
            // Przerywamy dzia�anie w tym miejscu
            return;
        }

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
        shootAudio.Play();
        Debug.Log("Shoot");
        Bullet bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }

    public void OnClick()
    {
        Debug.Log("Clicked on player");
    }
}
