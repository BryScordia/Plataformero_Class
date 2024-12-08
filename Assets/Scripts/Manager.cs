using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Cambiar a una escena específica por nombre
    public void CambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    // Salir del juego
    public void Salir()
    {
        Application.Quit();
    }
}
