using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSound : MonoBehaviour
{
    public AudioSource audioSource;  // Componente AudioSource que reproducir� el sonido
    public AudioClip interactionSound;  // Clip de sonido que se reproducir� al interactuar
    private bool isPlayerInRange = false;  // Verifica si el jugador est� dentro del �rea

    // Update is called once per frame
    void Update()
    {
        // Si el jugador est� en rango y presiona la tecla 'E'
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PlayInteractionSound();
        }
    }

    // M�todo que reproduce el sonido
    void PlayInteractionSound()
    {
        if (audioSource != null && interactionSound != null)
        {
            audioSource.clip = interactionSound;
            audioSource.Play();
        }
    }

    // Detecta cuando el jugador entra en el �rea
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    // Detecta cuando el jugador sale del �rea
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
