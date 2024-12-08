using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropR : MonoBehaviour
{
    // Diccionario para almacenar los objetos y sus posiciones objetivo en 2D
    private Dictionary<GameObject, Transform> objectsAndTargets = new Dictionary<GameObject, Transform>();

    private Vector2 initialPosition; // Posici�n inicial del objeto a mover
    private float deltaX, deltaY; // Diferencia de posici�n con respecto al mouse en el plano 2D
    private bool isDragging = false; // Estado de arrastre del objeto actual

    // Configura los elementos y sus lugares objetivos
    [SerializeField] private GameObject bocina, valvula, valvula2, tapa, boton, cable;
    [SerializeField] private Transform targetBocina, targetValvula, targetValvula2, targetTapa, targetBoton, targetCable;

    // Bot�n de la UI que se activar� cuando todos los objetos est�n en sus posiciones
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

        // Asegurarse de que el bot�n est� desactivado al inicio
        if (uiButton != null)
        {
            uiButton.gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (objectsAndTargets.ContainsKey(gameObject)) // Solo permite arrastrar si el objeto est� en la lista
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
            // Verifica si el objeto est� cerca de su posici�n objetivo
            if (objectsAndTargets.TryGetValue(gameObject, out Transform target) &&
                Vector2.Distance(transform.position, target.position) <= 0.3f)
            {
                // Ajusta la posici�n al objetivo y fija el objeto
                transform.position = target.position;
                isDragging = false;
                enabled = false; // Desactiva el script para este objeto para que no se vuelva a arrastrar

                // Verifica si todos los objetos est�n en sus posiciones
                CheckAllObjectsInPlace();
            }
            else
            {
                // Regresa el objeto a su posici�n inicial si no se solt� en el lugar correcto
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
                // Si alg�n objeto no est� en su posici�n correcta, termina el chequeo
                return;
            }
        }

        // Si todos los objetos est�n en sus posiciones, activa el bot�n de la UI
        if (uiButton != null)
        {
            uiButton.gameObject.SetActive(true);
        }
    }
}

