using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSoundTrigger : MonoBehaviour
{
    public AudioSource audioSource;  // El componente AudioSource que reproducir� el sonido
    public AudioClip soundClip;      // El clip de sonido que se reproducir�

    // Aseg�rate de que el Collider2D del �rea tenga la propiedad "Is Trigger" activada
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra es el jugador
        if (other.CompareTag("Player"))
        {
            // Si el audio no se est� reproduciendo, lo reproducimos
            if (!audioSource.isPlaying)
            {
                audioSource.clip = soundClip;
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica si el objeto que sale es el jugador
        if (other.CompareTag("Player"))
        {
            // Detener el sonido cuando el jugador salga del �rea
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
