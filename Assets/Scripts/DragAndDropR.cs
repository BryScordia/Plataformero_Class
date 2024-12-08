using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropR : MonoBehaviour
{
    // Diccionario para almacenar los objetos y sus posiciones objetivo en 2D
    private Dictionary<GameObject, Transform> objectsAndTargets = new Dictionary<GameObject, Transform>();

    private Vector2 initialPosition; // Posición inicial del objeto a mover
    private float deltaX, deltaY; // Diferencia de posición con respecto al mouse en el plano 2D
    private bool isDragging = false; // Estado de arrastre del objeto actual

    // Configura los elementos y sus lugares objetivos
    [SerializeField] private GameObject bocina, valvula, valvula2, tapa, boton, cable;
    [SerializeField] private Transform targetBocina, targetValvula, targetValvula2, targetTapa, targetBoton, targetCable;

    // Botón de la UI que se activará cuando todos los objetos estén en sus posiciones
    [SerializeField] private Button uiButton;

    void Start()
    {
        // Agregar los objetos y sus objetivos al diccionario
        objectsAndTargets.Add(bocina, targetBocina);
        objectsAndTargets.Add(valvula, targetValvula);
        objectsAndTargets.Add(valvula2, targetValvula2);
        
        objectsAndTargets.Add(tapa, targetTapa);
        objectsAndTargets.Add(boton, targetBoton);
        objectsAndTargets.Add(cable, targetCable);

        // Asegurarse de que el botón esté desactivado al inicio
        if (uiButton != null)
        {
            uiButton.gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (objectsAndTargets.ContainsKey(gameObject)) // Solo permite arrastrar si el objeto está en la lista
        {
            isDragging = true;
            initialPosition = transform.position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            deltaX = mousePos.x - transform.position.x;
            deltaY = mousePos.y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x - deltaX, mousePos.y - deltaY);
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            // Verifica si el objeto está cerca de su posición objetivo
            if (objectsAndTargets.TryGetValue(gameObject, out Transform target) &&
                Vector2.Distance(transform.position, target.position) <= 0.3f)
            {
                // Ajusta la posición al objetivo y fija el objeto
                transform.position = target.position;
                isDragging = false;
                enabled = false; // Desactiva el script para este objeto para que no se vuelva a arrastrar

                // Verifica si todos los objetos están en sus posiciones
                CheckAllObjectsInPlace();
            }
            else
            {
                // Regresa el objeto a su posición inicial si no se soltó en el lugar correcto
                transform.position = initialPosition;
            }
        }
    }

    private void CheckAllObjectsInPlace()
    {
        foreach (var item in objectsAndTargets)
        {
            if (Vector2.Distance(item.Key.transform.position, item.Value.position) > 0.3f)
            {
                // Si algún objeto no está en su posición correcta, termina el chequeo
                return;
            }
        }

        // Si todos los objetos están en sus posiciones, activa el botón de la UI
        if (uiButton != null)
        {
            uiButton.gameObject.SetActive(true);
        }
    }
}

