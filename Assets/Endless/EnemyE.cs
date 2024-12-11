using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyE : MonoBehaviour
{
    public float speed = 3f; //depende 
    private Rigidbody2D Erb2d;

    // Start is called before the first frame update
    void Start()
    {
        Erb2d = GetComponent<Rigidbody2D>();
        Erb2d.velocity = Vector2.left * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
