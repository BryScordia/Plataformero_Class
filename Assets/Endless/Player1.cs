using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Animator Panim;//anim player
    public GameObject controller;//canvas

    public GameObject EGenerator;

    private AudioSource audioPlayer;
    public AudioClip salto;
    public AudioClip muerte;
    
    // Start is called before the first frame update
    void Start()
    {
        Panim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool gameplay =
            controller.GetComponent<Game1>//entrar a codigo
            ().gameState ==
            Game1.GameState.Playing;
        if (gameplay &&
            (Input.GetKeyDown("up")
            || Input.GetMouseButtonDown(0))) // || = 0
        {
            UpdateState("P_Jump");
            audioPlayer.clip = salto;
            audioPlayer.Play();
        }
    }
    
    public void UpdateState(string state = null)
    {
        if (state != null) //!= opuesto o diferente a...
        {
            Panim.Play(state); //estados diferentes a animacion 
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Choco con enemy"); // consola<<<<<<
            UpdateState("P_Die");
            controller.GetComponent<Game1>().gameState = Game1.GameState.End; //nombre codigo 
            EGenerator.SendMessage("CancelGenerator", true);
            controller.SendMessage("ResetTimeScale");

            controller.GetComponent<AudioSource>().Stop();
            audioPlayer.clip = muerte;
            audioPlayer.Play();
        }
        else if (other .gameObject.tag == "point")
        {
            controller.SendMessage("IncrasePoints");
        }
    }
}
