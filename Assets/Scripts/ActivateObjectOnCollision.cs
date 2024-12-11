using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSpriteOnCollision2D : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;  // Referencia al SpriteRenderer
    public GameObject opciones;  // Referencia al objeto opciones

    private void Start()
    {
        // Verifica que el SpriteRenderer est� asignado en el Inspector
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer == null)
            {
                Debug.LogWarning("No se encontr� un SpriteRenderer en el objeto ni se asign� uno en el Inspector.");
            }
        }

        // Verifica que el objeto opciones est� asignado en el Inspector
        if (opciones == null)
        {
            Debug.LogWarning("El objeto 'opciones' no est� asignado.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Activa el SpriteRenderer y el objeto 'opciones' cuando el jugador entra
            if (spriteRenderer != null)
                spriteRenderer.enabled = true;

            if (opciones != null)
                opciones.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Mantiene el SpriteRenderer y el objeto 'opciones' activos mientras el jugador est� dentro
            if (spriteRenderer != null)
                spriteRenderer.enabled = true;

            if (opciones != null)
                opciones.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Desactiva el SpriteRenderer y el objeto 'opciones' cuando el jugador sale
            if (spriteRenderer != null)
                spriteRenderer.enabled = false;

            if (opciones != null)
                opciones.SetActive(false);
        }
    }
}



