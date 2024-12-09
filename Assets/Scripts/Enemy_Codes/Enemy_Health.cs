using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public Enemy_Follow Enemy;
    public int Enemy_Health_Num = 1;
        
    void Update()
    {


        if (Enemy_Health_Num == 0)
        {
            Enemy.Enemy_Status = 4;
        }
    }

    public void Damage()
    {
        if (Enemy.Enemy_Status == 3)
        {
            Enemy_Health_Num -= 1;
        }
        }
}
