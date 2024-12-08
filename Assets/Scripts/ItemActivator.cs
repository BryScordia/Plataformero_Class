using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject gasolinaObject; // Referencia al objeto de gasolina

    void Update()
    {
        UpdateObjectState();
    }

    public void UpdateObjectState()
    {
        // Verifica si gasolinaObject es nulo antes de acceder a él
        if (gasolinaObject != null)
        {
            // Comprueba si el item "Gasolina" está en el inventario
            if (InventoryManager.Instance.HasItem("Gasolina"))
            {
                gasolinaObject.SetActive(true); // Activa el objeto en la escena
            }
            else
            {
                gasolinaObject.SetActive(false); // Desactiva el objeto si no está en el inventario
            }
        }
    }
}
