using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject creditsButton; // Arrastra el bot�n desde el Inspector

    void Start()
    {
        // Verifica si el jugador ha desbloqueado los cr�ditos
        if (PlayerPrefs.GetInt("CreditsUnlocked", 0) == 1)
        {
            creditsButton.SetActive(true); // Activa el bot�n
        }
        else
        {
            creditsButton.SetActive(false); // Mantiene el bot�n desactivado
        }
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Creditos"); // Cambia "CreditsScene" al nombre de tu escena de cr�ditos
    }
}
