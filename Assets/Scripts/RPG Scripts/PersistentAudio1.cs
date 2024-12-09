using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentAudio1 : MonoBehaviour
{
    public static PersistentAudio1 instance;
    public AudioSource audioSource;  // Añadir el AudioSource que controlará la música

    void Awake()
    {
        // Evita que el objeto se duplique cuando se carguen nuevas escenas
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruir este objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Destruir duplicados si ya existe uno
        }
    }

    // Método para pausar o reanudar la música
    public void PauseOrPlayMusic()
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause(); // Pausar la música
            }
            else
            {
                audioSource.Play(); // Reanudar la música
            }
        }
    }
}
