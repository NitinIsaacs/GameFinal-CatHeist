using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject characterModel;
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    public float jumpForce = 5f;
    private int jumpCount = 0;
    private int maxJumpCount = 2;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        // Adjust for isometric view
        Vector3 isoDirection = Quaternion.Euler(0, 45, 0) * direction;
        
        
        if (isoDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(isoDirection, Vector3.up);
            characterModel.transform.rotation = Quaternion.Lerp(characterModel.transform.rotation, toRotation, Time.deltaTime * rotationSpeed);
        }

        // Jump
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            jumpCount++;
        }
    }

    void FixedUpdate()
    {
        // Movement
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 isoDirection = Quaternion.Euler(0, 45, 0) * direction;
        rb.MovePosition(rb.position + isoDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Reset jumpCount when the character lands
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}
