using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss_System : MonoBehaviour
{
    public GameObject[] Enemys;
    public Coins_System Game_Status;


    // Update is called once per frame
    void Update()
    {

        if (Enemys == null)
        {
            return;
        }

        for (int i = 0; i <= Enemys.Length; i++) 
        {

            if (Game_Status.Points_Enemys >= i && i <= Enemys.Length-1)
            {
                Enemys[i].GetComponent<Enemy_Follow>().Enemy_Behaviour(3);
}
        }
    }
}
