using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    [Header("Configuração do Mouse")]
    public float mouseSensitivity = 200f;
    public Transform playerCamera;

    private Rigidbody rb;
    private bool isGrounded = true;
    private float xRotation = 0f;

    // INPUT SYSTEM
    private Vector2 moveInput;
    private Vector2 mouseInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Registra o PlayerInput no GameManager
        GameManager.instance.ConfigurarInput(GetComponent<PlayerInput>());
    }

    void Update()
    {
        // --- ROTAÇÃO (MOUSE) ---
        float mouseX = mouseInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {
        // --- MOVIMENTO ---
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }

    // --- INPUT SYSTEM METHODS ---

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}