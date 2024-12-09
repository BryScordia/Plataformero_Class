using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSound : MonoBehaviour
{
    public AudioSource audioSource;  // Componente AudioSource que reproducirá el sonido
    public AudioClip attackSoundClip;  // El clip de sonido que se reproducirá para el ataque

    // Método para reproducir el sonido de ataque
    public void PlayAttackSound()
    {
        if (audioSource != null && attackSoundClip != null)
        {
            audioSource.clip = attackSoundClip;
            audioSource.Play();
        }
    }
}
