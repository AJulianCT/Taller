using UnityEngine;
using UnityEngine.UI; // Para mostrar el mensaje en pantalla

public class AgentWinCheck : MonoBehaviour
{
    // Texto UI para mostrar el mensaje de victoria
    public Text winText;

    private void Start()
    {
        // Asegurarse de que el mensaje de victoria esté oculto al inicio
        winText.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona es el agente
        if (collision.gameObject.name == "Agent")
        {
            // Mostrar el mensaje "¡Has ganado!"
            winText.gameObject.SetActive(true);
            winText.text = "¡Has ganado!";

            // Ocultar el mensaje después de 3 segundos
            Invoke("HideWinText", 2f);
        }
    }

    // Método para ocultar el mensaje de victoria
    private void HideWinText()
    {
        winText.gameObject.SetActive(false);
    }
}
