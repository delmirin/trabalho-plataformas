using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerLegacy : MonoBehaviour
{
    [SerializeField] float speed = 10f;         // Força aplicada
    [SerializeField] float maxSpeed = 8f;       // Velocidade máxima (magnitude)
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        // Opcional: ajustar drag no Rigidbody ou deixar via Inspector
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(h, 0f, v);
        if (input.sqrMagnitude > 1f) input.Normalize();

        Vector3 force = input * speed;
        rb.AddForce(force, ForceMode.Force);

        // Clamp na velocidade horizontal para não crescer indefinidamente
        Vector3 horizontalVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (horizontalVel.magnitude > maxSpeed)
        {
            Vector3 clamped = horizontalVel.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(clamped.x, rb.linearVelocity.y, clamped.z);
        }
    }
}