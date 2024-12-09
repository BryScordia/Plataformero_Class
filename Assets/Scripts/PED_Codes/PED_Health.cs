using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PED_Health : MonoBehaviour
{

    public PED_Follow PED;
    public int PED_Health_Num = 1;
        
    void Update()
    {

        if (PED_Health_Num == 0)
        {

            PED.PED_Status = 2;
        }
    }



    public void Damage()
    {
        if (PED.PED_Status == 1)
        {
            PED_Health_Num -= 1;
        }
    }
}
