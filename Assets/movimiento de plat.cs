using UnityEngine;

public class MovimientoInfinitoConInteraccion : MonoBehaviour
{
    public float velocidad = 2.0f; // Velocidad del movimiento
    public float distancia = 3.0f; // Distancia que recorrerá en cada dirección
    private Vector3 posicionInicial;
    private bool moverDerecha = true; // Controla si se mueve a la derecha o izquierda
    private bool tocadoPorAgente = false; // Indica si el objeto está siendo tocado por el agente
    private Transform agenteTransform; // Referencia al transform del agente
    private Vector3 ultimaPosicion; // Guarda la última posición de la plataforma

    void Start()
    {
        posicionInicial = transform.position;
        ultimaPosicion = transform.position; // Inicializa la última posición
    }

    void Update()
    {
        // Movimiento infinito del objeto de derecha a izquierda
        if (moverDerecha)
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime); // Mover a la derecha
            if (Vector3.Distance(transform.position, posicionInicial) >= distancia)
            {
                moverDerecha = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime); // Mover a la izquierda
            if (Vector3.Distance(transform.position, posicionInicial) <= 0.1f)
            {
                moverDerecha = true;
            }
        }

        // Si el agente está tocando la plataforma, moverlo junto con ella
        if (tocadoPorAgente && agenteTransform != null)
        {
            Vector3 desplazamiento = transform.position - ultimaPosicion; // Calcula el desplazamiento de la plataforma
            agenteTransform.position += desplazamiento; // Aplica el desplazamiento al agente
        }

        // Actualiza la última posición de la plataforma
        ultimaPosicion = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que colisiona es el agente con tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            tocadoPorAgente = true;
            agenteTransform = collision.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Cuando el agente se separa, detiene el seguimiento
        if (collision.gameObject.CompareTag("Player"))
        {
            tocadoPorAgente = false;
            agenteTransform = null;
        }
    }
}
