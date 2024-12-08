using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivatorR : MonoBehaviour
{
    // Objeto a activar cuando se cumpla la condici�n
    [SerializeField]
    private GameObject objectToActivate;

    // Lista de los elementos requeridos
    private List<string> requiredItems = new List<string>
    {
        "Bocina",
        "Microfono",
        "Valvula",
        "Valvula2",
        "Radio",
        "Tapa"
    };

    private void Start()
    {
        // Desactiva el objeto inicialmente
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }
        else
        {
            Debug.LogWarning("El objeto a activar no ha sido asignado en el inspector.");
        }
    }

    private void Update()
    {
        // Comprueba si todos los elementos est�n en el inventario
        if (AllItemsInInventory())
        {
            ActivateObject();
        }
    }

    private bool AllItemsInInventory()
    {
        foreach (string item in requiredItems)
        {
            if (!InventoryManager.Instance.HasItem(item)) // Verifica si el inventario contiene cada elemento
            {
                return false; // Si falta uno, regresa falso
            }
        }
        return true; // Todos los elementos est�n presentes
    }

    private void ActivateObject()
    {
        if (objectToActivate != null && !objectToActivate.activeSelf)
        {
            objectToActivate.SetActive(true); // Activa el objeto solo si est� desactivado
            Debug.Log("Todos los elementos est�n en el inventario. Activando el objeto.");
        }
    }
}
