using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject creditsButton; // Arrastra el botón desde el Inspector

    void Start()
    {
        // Verifica si el jugador ha desbloqueado los créditos
        if (PlayerPrefs.GetInt("CreditsUnlocked", 0) == 1)
        {
            creditsButton.SetActive(true); // Activa el botón
        }
        else
        {
            creditsButton.SetActive(false); // Mantiene el botón desactivado
        }
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Creditos"); // Cambia "CreditsScene" al nombre de tu escena de créditos
    }
}
