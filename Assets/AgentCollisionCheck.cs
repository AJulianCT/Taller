using UnityEngine;
using UnityEngine.UI; // Para mostrar el mensaje en pantalla

public class AgentCollisionCheck : MonoBehaviour
{
    // Texto UI para mostrar el mensaje de pérdida
    public Text loseText;

    // Color del objeto que se puede establecer manualmente en el Inspector
    public Color objectColor;

    private void Start()
    {
        // Cambiar el color del material del objeto al color establecido
        GetComponent<Renderer>().material.color = objectColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona es el agente
        if (collision.gameObject.name == "Agent")
        {
            // Obtener el componente Renderer del agente
            Renderer agentRenderer = collision.gameObject.GetComponent<Renderer>();
            // Obtener el componente Renderer del objeto en el que está colisionando
            Renderer objectRenderer = GetComponent<Renderer>();

            // Verificar si ambos objetos tienen el mismo color
            if (agentRenderer.material.color == objectRenderer.material.color)
            {
                // Si el color coincide, el agente puede caminar sobre el objeto
                Debug.Log("Colores coinciden. Puedes caminar sobre el objeto.");
            }
            else
            {
                // Si el color no coincide, restablecer posición y rotación del agente
                collision.gameObject.transform.position = new Vector3(13, 1, 13); // Mover a la posición (13, 1, 13)
                collision.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0); // Rotar a (0, 0, 0)
                
                // Mostrar el mensaje "Has perdido"
                loseText.gameObject.SetActive(true);
                loseText.text = "¡Has perdido!";

                // Desactivar el mensaje después de 2 segundo
                Invoke("HideLoseText", 2f);
            }
        }
    }

    // Método para ocultar el mensaje de pérdida
    private void HideLoseText()
    {
        loseText.gameObject.SetActive(false);
    }
}
