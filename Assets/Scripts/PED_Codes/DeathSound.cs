using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    public AudioSource audioSource;  // Componente AudioSource que reproducirá el sonido
    public AudioClip deathSoundClip;  // El clip de sonido que se reproducirá cuando el PED muera

    // Método para reproducir el sonido de muerte
    public void PlayDeathSound()
    {
        if (audioSource != null && deathSoundClip != null)
        {
            audioSource.clip = deathSoundClip;
            audioSource.Play();
        }
    }
}
