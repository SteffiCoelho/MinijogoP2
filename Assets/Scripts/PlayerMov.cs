using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;
    public float mouseSensitivity = 0.1f;
    [SerializeField] Transform cameraTransform;
    public float pitch;

    private Vector2 moveInput;
    private Vector2 lookInput;
    

    float moveX;
    float moveZ;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Movimenta��o
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        //Camera
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        //Rota��o
        transform.Rotate(Vector3.up * mouseX);

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -85f, 85f);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0);

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            isGrounded = false;
        }
       
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
  
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 direction = transform.forward * moveZ + transform.right * moveX;
        Vector3 velocity = new Vector3(direction.x * speed, rb.linearVelocity.y, direction.z * speed);

        rb.linearVelocity = velocity;
    }
}