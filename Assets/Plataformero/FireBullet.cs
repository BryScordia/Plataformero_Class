using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;
    private float direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D
        rb.velocity = transform.right * speed * direction; // Mover la bala hacia la derecha o izquierda
    }

    public void SetDirection(float direction)
    {
        this.direction = direction;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); // Destruir la bala si sale de la pantalla
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject); // Destruir la bala si colisiona con un objeto con el tag "Ground"
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Destruir el enemigo
            Destroy(gameObject); // Destruir la bala
        }
    }
}
