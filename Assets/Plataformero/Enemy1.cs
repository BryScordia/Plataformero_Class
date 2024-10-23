using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float moveSpeed = 3f; //variar
    private Rigidbody2D ERB;
    private Animator Eanim;  
    private bool moveLeft; //Espejo
    public Transform down_Collision;//detecta el suelo
    //public Transform top_Collision;// detecta al player
    private bool Move;
    private bool Sleep;
    public LayerMask PlayerLayer;


        void Awake()
    {
        ERB = GetComponent<Rigidbody2D>();
        Eanim = GetComponent<Animator>();
    }
    void Start()
    {
        moveLeft = true;
        Move = true;
    }


    void Update()
    {
     if (Move)
      {
       if (moveLeft)
        {
    ERB.velocity = 
    new Vector2(-moveSpeed, ERB.velocity.y);//izq
            }
            else
            {
    ERB.velocity = new Vector2(moveSpeed, ERB.velocity.y);//derecha
            }
        }
        CheckCollision();
    }
    void CheckCollision()
    {
        if (!Physics2D.Raycast
            (down_Collision.position, Vector2.down, 0.9f))
        {  
            ChangeDirection();
        } }
    void ChangeDirection()
    {
        moveLeft = !moveLeft;
        Vector3 tempScale = transform.localScale;
        if (moveLeft)
        {
            tempScale.x = Mathf.Abs(tempScale.x);//izq
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);//derecha
        }
        transform.localScale = tempScale;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject); // Destruir el enemigo
        }
    }


}