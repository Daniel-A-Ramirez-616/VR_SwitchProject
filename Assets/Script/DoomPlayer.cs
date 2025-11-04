using UnityEngine;

public class DoomPlayer : MonoBehaviour
{
    private Vector2 moveInput;
    private Vector2 mouseInput;
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public float rotationrate = 180f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHorizontal = transform.up * -moveInput.x;

        Vector3 moveVertical = transform.right * moveInput.y;

        rb.linearVelocity = (moveHorizontal + moveVertical) * moveSpeed;

    }
}
