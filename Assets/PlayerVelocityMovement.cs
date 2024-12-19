using UnityEngine;

public class PlayerVelocityMovement : MonoBehaviour
{
    public float velocity = 1f;
    private Rigidbody rb;
    Vector3 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, verticalInput, 0);
        //if(movementDirection.sqrMagnitude > 1)
        //{
        //    movementDirection = movementDirection.normalized;
        //}
        movementDirection = Vector3.ClampMagnitude(movementDirection, 1);

        rb.linearVelocity = movementDirection * velocity;
    }
}
