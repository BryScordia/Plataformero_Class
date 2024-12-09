using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControlButton : MonoBehaviour
{
    // Este m�todo se llamar� cuando se presione el bot�n
    public void OnButtonClick()
    {
        // Acceder a la instancia de PersistentAudio1 y llamar al m�todo para pausar o reanudar la m�sica
        if (PersistentAudio1.instance != null)
        {
            PersistentAudio1.instance.PauseOrPlayMusic();
        }
    }
}
