using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //User Interface
using UnityEngine.SceneManagement;

public class Game2 : MonoBehaviour
{
    public RawImage background; // Fondo 1
    public RawImage background2; // Fondo 2
    public RawImage background3; // Fondo 3
    public RawImage platform; // Piso
    public RawImage Capa2; // Capa 2
    public RawImage Capa3; // Capa 3
    public RawImage Capa4; // Capa 4
    public float parallaxSpeed = 0.2f; // Velocidad del fondo 1
    public float parallaxSpeed2 = 0.15f; // Velocidad del fondo 2
    public float parallaxSpeed3 = 0.1f; // Velocidad del fondo 3
    public float Speed1 = 0.2f; // Velocidad del piso
    public float Speed2 = 0.2f; // Velocidad de la Capa 2
    public float Speed3 = 0.1f; // Velocidad de la Capa 3
    public float Speed4 = 0.05f; // Velocidad de la Capa 4
    public enum GameState { Wait, Playing, End }; //
    public GameState gameState = GameState.Wait; // Estado inicial del juego 
    public GameObject uiWait; // UI inicial
    public GameObject player;
    public GameObject EnemyGenerator;
    private int points = 0;
    public Text txtpoints;
    public GameObject scoreUI; // UI de puntos
    private AudioSource music;

    public float scale = 7f; // Intervalo para aumentar velocidad
    public float increment = 0.2f; // Incremento de velocidad
    public GameObject uiEnd;

    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gameState == GameState.Wait &&
            (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {
            gameState = GameState.Playing; // Inicio juego
            uiWait.SetActive(false); // Ocultar UI inicial
            player.GetComponent<Animation>().SetAnimation("P_Run"); // Mantener SetAnimation
            EnemyGenerator.SendMessage("StartGenerator");
            InvokeRepeating("GameTimeScale", scale, scale);
            scoreUI.SetActive(true); // Activar puntos
            music.Play(); // Inicia la música
        }
        else if (gameState == GameState.End)
        {
            uiEnd.SetActive(true);
            EnemyGenerator.SendMessage("CancelGenerator", true);
        }
        else if (gameState == GameState.Playing)
        {
            float deltaTime = Time.deltaTime;

            // Movimiento de fondos
            background.uvRect = new Rect(
                background.uvRect.x + parallaxSpeed * deltaTime, 0f, 1f, 1f);
            background2.uvRect = new Rect(
                background2.uvRect.x + parallaxSpeed2 * deltaTime, 0f, 1f, 1f);
            background3.uvRect = new Rect(
                background3.uvRect.x + parallaxSpeed3 * deltaTime, 0f, 1f, 1f);

            // Movimiento del piso y capas
            platform.uvRect = new Rect(
                platform.uvRect.x + Speed1 * deltaTime, 0f, 1f, 1f);
            Capa2.uvRect = new Rect(
                Capa2.uvRect.x + Speed2 * deltaTime, 0f, 1f, 1f);
            Capa3.uvRect = new Rect(
                Capa3.uvRect.x + Speed3 * deltaTime, 0f, 1f, 1f);
            Capa4.uvRect = new Rect(
                Capa4.uvRect.x + Speed4 * deltaTime, 0f, 1f, 1f);
        }
    }

    void GameTimeScale()
    {
        Time.timeScale += increment;
        Debug.Log("Velocidad aumenta: " + Time.timeScale.ToString());
    }

    public void ResetTimeScale()
    {
        CancelInvoke("GameTimeScale");
        Time.timeScale = 1f;
        Debug.Log("Velocidad normal: " + Time.timeScale.ToString());
    }

    public void IncrasePoints()
    {
        txtpoints.text = (++points).ToString();
       
    }

    public void ResetGame()
    {
        points = 0;
        txtpoints.text = points.ToString();
        Time.timeScale = 1f;
        gameState = GameState.Wait;

        uiWait.SetActive(true);
        uiEnd.SetActive(false);
    }

    public void SceneMenu()
    {
        SceneManager.LoadScene("Intro"); // Cambia "CreditsScene" al nombre de tu escena de créditos
    }

}

