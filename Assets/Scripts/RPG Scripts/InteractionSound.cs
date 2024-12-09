using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSound : MonoBehaviour
{
    public AudioSource audioSource;  // Componente AudioSource que reproducirá el sonido
    public AudioClip interactionSound;  // Clip de sonido que se reproducirá al interactuar
    private bool isPlayerInRange = false;  // Verifica si el jugador está dentro del área

    // Update is called once per frame
    void Update()
    {
        // Si el jugador está en rango y presiona la tecla 'E'
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PlayInteractionSound();
        }
    }

    // Método que reproduce el sonido
    void PlayInteractionSound()
    {
        if (audioSource != null && interactionSound != null)
        {
            audioSource.clip = interactionSound;
            audioSource.Play();
        }
    }

    // Detecta cuando el jugador entra en el área
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    // Detecta cuando el jugador sale del área
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
