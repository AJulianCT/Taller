using UnityEngine;

public class AgentStateController : MonoBehaviour
{
    // Definición de los 10 colores
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public Color color3 = Color.green;
    public Color color4 = Color.yellow;
    public Color color5 = new Color(1f, 0.5f, 0f); // Naranja
    public Color color6 = Color.white;

    // Material del agente
    private Renderer agentRenderer;

    void Start()
    {
        // Obtiene el Renderer del agente para cambiar su color
        agentRenderer = GetComponent<Renderer>();

        // Establece un color inicial
        agentRenderer.material.color = color6;
    }

    void Update()
    {
        // Cambiar el color según el número presionado
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            ChangeColor(color1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            ChangeColor(color2);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            ChangeColor(color3);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            ChangeColor(color4);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            ChangeColor(color5);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            ChangeColor(color6);
        }
    }

    // Método para cambiar el color del agente
    private void ChangeColor(Color newColor)
    {
        agentRenderer.material.color = newColor;
    }
}
