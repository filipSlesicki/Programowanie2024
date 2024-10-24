using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth = 5;
    public float regenRate = 1;
    public bool isOverFullHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float missingHealth = maxHealth - currentHealth;
        float timeToRegen = missingHealth / regenRate;
        Debug.Log("It will take " + timeToRegen + " seconds to regenerate to full health");

    }

    // Update is called once per frame
    void Update()
    {


        isOverFullHealth = currentHealth > maxHealth;
        bool isDead = currentHealth <= 0;
        bool isAlive = currentHealth > 0;
        isAlive = !isDead;
        bool isOverHalfHealth = currentHealth > maxHealth / 2;
        bool shouldBeHealed = currentHealth > 0 && currentHealth <= maxHealth;
        bool shouldNotBeHealed = currentHealth <= 0 || currentHealth >= maxHealth;

        //if (shouldBeHealed)
        //{
        //    currentHealth += regenRate * Time.deltaTime;
        //    if (currentHealth > maxHealth)
        //    {
        //        currentHealth = maxHealth;
        //    }
        //}

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentHealth += 1;
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentHealth -= 1;
            if(currentHealth < 0)
            {
                currentHealth = 0;
            }
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space was pressed");
        }
    }
}
