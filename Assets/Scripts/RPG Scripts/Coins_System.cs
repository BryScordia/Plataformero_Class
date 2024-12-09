using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins_System : MonoBehaviour
{
    public GameObject Next_Level;
    public Player_Lifes Game_Status;


    public GameObject Panel_Knifes, Panel_PEDs, Panel_Enemys;
    public TMP_Text Text_Points_Knifes, Text_Points_PEDs, Text_Points_Enemys;
    public int Points_Knifes, Points_PEDs, Points_Enemys;

    [Header("Timer")]
    public TextMeshProUGUI Timer_Text;
    public float Timer_Start;
    public float Timer;
    private bool Pause_Timer;

    [Header("Points Config")]

    public int Max_Points_Knifes, Max_Points_PEDs, Max_Points_Enemys;

    public bool Knifes, PEDs, Enemys;

    private void Start()
    {
        Timer = Timer_Start;
        Pause_Timer = false;


        Points_Knifes = 0;
        Points_PEDs = 0;
        Points_Enemys = 0;
        Update_Text();
    }

    private void Update()
    {

        if (!Pause_Timer)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Timer = 0;

                Game_Status.GameOver();
            }
            Update_Text();
        }


    Panel_Knifes.gameObject.SetActive(Knifes);
        Panel_PEDs.gameObject.SetActive(PEDs);
        Panel_Enemys.gameObject.SetActive(Enemys);


        if (Points_Knifes >= Max_Points_Knifes && Points_PEDs >= Max_Points_PEDs && Points_Enemys >= Max_Points_Enemys)
        {
            Next_Level.gameObject.SetActive(true);
        }
    }

    public void Counter_Status(bool Status)
    {
        Pause_Timer = Status;
    }

    public void Add_Points(int Point_Status, int cantidad)
    {
  

        switch (Point_Status)
        {
            case 1:
                Points_Knifes += cantidad; ;
                break;
            case 2:
                Points_PEDs += cantidad;
                break;
            case 3:
                Points_Enemys += cantidad; ;
                break;
        }
        Update_Text();
    }

    private void Update_Text()
    {
        int minutos = (int)(Timer / 60);
        int segundos = (int)(Timer % 60);
        Timer_Text.text = $"{minutos:D2}:{segundos:D2}";

        Text_Points_Knifes.text = Max_Points_Knifes + "/" + Points_Knifes.ToString();
        Text_Points_PEDs.text = Max_Points_PEDs+ "/" + Points_PEDs.ToString();
        Text_Points_Enemys.text = Max_Points_Enemys + "/" + Points_Enemys.ToString();
    }
}
