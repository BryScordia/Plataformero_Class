using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Agregado para usar SceneManager

public class Player : MonoBehaviour
{
    Rigidbody2D PlayerRB;
    public float PSpeed = 6f;
    Animator Panim;
    public Transform groundcheck;
    public LayerMask groundlayer;
    private bool isGround;
    private bool jumped;
    public float jumpPower = 7f;
    private int coinCount = 0; // Contador de monedas
    public Text coinText; // Referencia al texto UI
    public Transform checkpoint; // Referencia al GameObject Checkpoint

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        Panim = GetComponent<Animator>();
        UpdateCoinUI();
    }

    void Update()
    {
        CheckIfGrounded(); // revisando suelo
        PlayerJump();
    }

    void FixedUpdate()
    {
        PlayerWalk();
    }

    void PlayerWalk()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            PlayerRB.velocity = new Vector2(PSpeed, PlayerRB.velocity.y);
            ChangeDirection(1); // derecha
        }
        else if (h < 0)
        {
            PlayerRB.velocity = new Vector2(-PSpeed, PlayerRB.velocity.y);
            ChangeDirection(-1); // izquierda
        }
        else
        {
            PlayerRB.velocity = new Vector2(0f, PlayerRB.velocity.y); // Idle
        }
        Panim.SetInteger("Speed", Mathf.Abs((int)PlayerRB.velocity.x));
    }

    void ChangeDirection(int direction) // espejo  
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    void CheckIfGrounded() // suelo
    {
        isGround = Physics2D.Raycast(groundcheck.position, Vector2.down, 0.2f, groundlayer); // Ground
        if (isGround)
        {
            if (jumped)
            {
                jumped = false;    // evitar 2 saltos
                Panim.SetBool("Jump", false);
            }
        }
    }

    void PlayerJump()
    {
        if (isGround)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                jumped = true;     // activa el salto
                PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, jumpPower);
                Panim.SetBool("Jump", true);
            }
        }
    }

    public void AddCoin()
    {
        coinCount++;
        Debug.Log("Coins: " + coinCount);
        UpdateCoinUI();
    }

    void UpdateCoinUI()
    {
        coinText.text = "MONEDAS: " + coinCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Colisión con los picos
        if (collision.CompareTag("Picos"))
        {
            Debug.Log("Jugador tocó los picos. Teletransportando al checkpoint...");
            if (checkpoint != null)
            {
                transform.position = checkpoint.position; // Mueve al jugador al checkpoint
            }
            else
            {
                Debug.LogWarning("Checkpoint no asignado en el inspector.");
            }
        }

        // Colisión con el portal (nuevo código agregado)
        if (collision.gameObject.CompareTag("Portal"))
        {
            Debug.Log("Jugador tocó el portal. Cambiando de escena...");
            SceneManager.LoadScene("D&D");  // Cambia a la escena "Nivel 2"
        }
    }
}
