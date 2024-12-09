using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControlButton : MonoBehaviour
{
    // Este método se llamará cuando se presione el botón
    public void OnButtonClick()
    {
        // Acceder a la instancia de PersistentAudio1 y llamar al método para pausar o reanudar la música
        if (PersistentAudio1.instance != null)
        {
            PersistentAudio1.instance.PauseOrPlayMusic();
        }
    }
}
