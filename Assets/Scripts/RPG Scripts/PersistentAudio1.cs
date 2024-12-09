using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentAudio1 : MonoBehaviour
{
    public static PersistentAudio1 instance;
    public AudioSource audioSource;  // A�adir el AudioSource que controlar� la m�sica

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

    // M�todo para pausar o reanudar la m�sica
    public void PauseOrPlayMusic()
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause(); // Pausar la m�sica
            }
            else
            {
                audioSource.Play(); // Reanudar la m�sica
            }
        }
    }
}
