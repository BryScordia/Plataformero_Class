using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    [SerializeField]
    private Transform imgPlace; // coordenadas del receptor
    private Vector2 PosIni; // pos inicial del objeto a mover
    private Vector2 mouseP; // pos inicial del mouse
    private float deltaX, deltaY; // coordenadas X & Y
    public bool locked = false; // Fijar cuando llega a la base (cambiar de static a normal)

    // Variable para el AudioSource
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        PosIni = transform.position; // obtener coord
        audioSource = GetComponent<AudioSource>(); // Obtener el AudioSource
    }

    private void OnMouseDown() // clic
    {
        if (!locked)
        { // !=opuesto
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag() // arrastrar objeto
    {
        if (!locked)
        {
            mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mouseP.x - deltaX, mouseP.y - deltaY);
        }
    }

    private void OnMouseUp() // al soltar
    {
        if (Mathf.Abs(transform.position.x - imgPlace.position.x) <= 0.3f &&
            Mathf.Abs(transform.position.y - imgPlace.position.y) <= 0.3f)
        {
            transform.position = new Vector2(imgPlace.position.x, imgPlace.position.y);
            locked = true; // imagen fija

            // Reproducir el sonido al colocar la imagen correctamente
            audioSource.Play();

            // Destruir el objeto
            Destroy(gameObject); // Destruye este objeto
        }
        else
        {
            transform.position = new Vector2(PosIni.x, PosIni.y);
        }
    }
}
