using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    // Velocidad de movimiento
    public float moveSpeed = 5f;

    // Velocidad de rotación
    public float rotationSpeed = 300f;

    // Fuerza de salto
    public float jumpForce = 5f;

    // Comprobación de si el agente está en el suelo
    private bool isGrounded;

    // Componente Rigidbody
    private Rigidbody rb;

    void Start()
    {
        // Obtener el componente Rigidbody del agente
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento en el eje Z y rotación en el eje Y
        float moveHorizontal = Input.GetAxis("Horizontal"); // Izquierda-Derecha (giro)
        float moveVertical = Input.GetAxis("Vertical"); // Adelante-Atrás (movimiento)

        // Calcular el vector de movimiento en el eje Z (adelante y atrás)
        Vector3 movement = transform.forward * moveVertical;

        // Aplicar el movimiento en el eje Z
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Aplicar la rotación en el eje Y cuando se presionan A o D
        if (moveHorizontal != 0)
        {
            float rotation = moveHorizontal * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotation, 0);
        }

        // Saltar cuando se presiona la barra espaciadora y el agente está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // Detectar si el agente toca el suelo para permitir el salto
    private void OnCollisionEnter(Collision collision)
    {
        // Comprobar si el agente está en contacto con cualquier superficie
        if (collision.contacts.Length > 0)
        {
            // Verificar que el contacto esté en la parte inferior del agente
            foreach (ContactPoint contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Cuando el agente se separa de cualquier superficie, ya no está en el suelo
        isGrounded = false;
    }
}
