using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Collider : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "L�mite")
        {
            Debug.Log("Colisi�n con el l�mite detectada.");
        }
    }
}
