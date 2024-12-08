using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSpriteOnCollision2D : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && spriteRenderer != null)
        {
            spriteRenderer.enabled = true; // Activa el SpriteRenderer al entrar
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && spriteRenderer != null)
        {
            spriteRenderer.enabled = true; // Mantiene el SpriteRenderer activo mientras est� dentro
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && spriteRenderer != null)
        {
            spriteRenderer.enabled = false; // Desactiva el SpriteRenderer al salir
        }
    }
}


