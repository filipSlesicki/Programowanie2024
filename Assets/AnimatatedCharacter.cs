using UnityEngine;

public class AnimatatedCharacter : MonoBehaviour
{
    public Animator animator;
    
    void Start()
    {
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float movementSpeed = new Vector2(forwardInput, horizontalInput).magnitude;
        animator.SetFloat("Movement", movementSpeed);
        animator.SetFloat("Vertical", forwardInput);
        animator.SetFloat("Horizontal", horizontalInput);

        if(Input.GetMouseButtonDown(0))
        {
            int randomAttack = Random.Range(0, 2);
            animator.SetInteger("AttackIndex", randomAttack);
            animator.SetTrigger("Attack");
        }
    }
}
