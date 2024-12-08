using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Singleton instance
    public static InventoryManager Instance { get; private set; }

    // Lista para almacenar los objetos del inventario
    public List<string> items = new List<string>();

    // Diccionario para mapear los nombres de los �tems a sus GameObjects
    public Dictionary<string, GameObject> itemObjects = new Dictionary<string, GameObject>();

    public GameObject gasolinaObject; // Objeto para Gasolina
    public GameObject bocinaObject;   // Objeto para Bocina
    public GameObject microfonoObject; // Objeto para Micr�fono
    public GameObject radioObject;
    public GameObject tapaObject;
    public GameObject valvulaObject;
    public GameObject valvula2Object;

    private void Awake()
    {
        // Verifica si ya existe una instancia del Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Evita que se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye esta
        }
    }

    private void Start()
    {
        // A�adir objetos al diccionario
        itemObjects.Add("Gasolina", gasolinaObject);
        itemObjects.Add("Bocina", bocinaObject);
        itemObjects.Add("Microfono", microfonoObject);
        itemObjects.Add("Radio", radioObject);
        itemObjects.Add("Tapa", tapaObject);
        itemObjects.Add("Valvula", valvulaObject);
        itemObjects.Add("Valvula2", valvula2Object);

        // Inicializa el inventario al inicio
        UpdateInventory();
    }

    // M�todo para a�adir un �tem
    public void AddItem(string item)
    {
        if (!items.Contains(item)) // Evita duplicados
        {
            items.Add(item);
            UpdateInventory(); // Actualiza el estado del inventario
        }
    }

    // M�todo para eliminar un �tem
    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            UpdateInventory(); // Actualiza el estado del inventario
        }
    }

    // M�todo para verificar si se tiene un �tem
    public bool HasItem(string item)
    {
        return items.Contains(item);
    }

    // M�todo para actualizar el estado de los objetos en la escena
    public void UpdateInventory()
    {
        // Verifica cada objeto en el diccionario
        foreach (var entry in itemObjects)
        {
            // Activa o desactiva el objeto seg�n si el �tem est� en el inventario
            entry.Value.SetActive(HasItem(entry.Key));
        }
    }
}




