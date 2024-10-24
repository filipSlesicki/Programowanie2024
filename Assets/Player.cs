using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Typy
    // int - liczba ca³kowita
    // float - liczba z przecinkiem
    // string - "Tekst"
    // bool - zmienna logiczna true/false

    public float velocity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        int a = 2;
        int b = 3;
        a = 6;
        b = 10;
        b = a;
        a = 4;
        int c = a + b;
        c = 1 + a;
        c = c + 1;
        c += 1;
        // Zwiêksza c o 1
        c++;
        // Dodaje 200 do c
        c += 200;
        c += a + b;
        c /= 2;
        

    }

    // Update is called once per frame
    void Update()
    {
        // FPS = 60
        //czas trfania klatki 1/60 - Time.deltaTime
        //transform.Translate(1 * Time.deltaTime,0,0);
        transform.Rotate(0, velocity * Time.deltaTime, 0);
    }
}
