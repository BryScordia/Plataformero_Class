using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject enemyprefab; // enemy prefab 
    public float generatortime = 3f; //inicial

    void CreateEnemy()
    {
        Instantiate // obj + pos + rot 
             (enemyprefab, transform.position, Quaternion.identity);
    }

    public void StartGenerator ()
    {
        InvokeRepeating("CreateEnemy", 3f, generatortime);
    }
    public void CancelGenerator(bool clean = false)
    {
        CancelInvoke("CreateEnemy");
        if(clean)
        {
            object[] allEnemy =
            GameObject.FindGameObjectsWithTag("Enemy"); //0bjects
            foreach(GameObject enemy in allEnemy)
            {
                Destroy(enemy);
            }
        }
    }
}
