using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    private void Awake()
    {
        // Asegurarse de que solo haya una instancia de AudioManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruir este objeto al cargar nuevas escenas
        }
        else
        {
            Destroy(gameObject); // Destruir el nuevo objeto AudioManager si ya existe uno
        }
    }

    private void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play(); // Solo reproduce si no está sonando
        }
    }

    public void StopMusic()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // Detiene la música si está sonando
        }
    }
}
