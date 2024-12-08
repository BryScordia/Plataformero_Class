using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Nombre del objeto que se a�adir� al inventario
    public string itemName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra al collider es el jugador
        if (other.CompareTag("Player"))
        {
            // Agregar el objeto al inventario
            InventoryManager.Instance.AddItem(itemName);

            // Mensaje opcional para confirmar que se recogi� el objeto
            Debug.Log($"{itemName} ha sido a�adido al inventario.");

            // Destruir el objeto despu�s de recogerlo
            Destroy(gameObject);
        }
    }
}
