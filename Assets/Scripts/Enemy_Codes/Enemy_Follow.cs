using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow : MonoBehaviour
{
    public Coins_System System;
    public Animator Enemy_Animator;

    public float speed;
    public float stoppingDistance;
    public float Follow_Limit;

    public bool Attack;

    private Transform target;
    public Vector2 Orientation;

    public int Enemy_Status = 1;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        switch (Enemy_Status)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                Enemy_Follow_Player();
                break;
            case 4:
                StartCoroutine(Enemy_Death());
                break;
            default:
                break;
        }
    }

    public void Enemy_Behaviour(int Behaviour)
    {
        Enemy_Status = Behaviour;
    }

    IEnumerator Enemy_Death()
    {
        Enemy_Animator.SetBool("Death", true);
        yield return new WaitForSeconds(.4f);
        System.Add_Points(3, 1);
        this.gameObject.SetActive(false);
    }



    public void Enemy_Follow_Player()
    {

        orientation_Enemy();
        idle_Enemy();



        if (Vector2.Distance(transform.position, target.position) > stoppingDistance && Vector2.Distance(transform.position, target.position) < Follow_Limit)
        {
            Enemy_Animator.SetFloat("Vertical_Run", Orientation.y);
            Enemy_Animator.SetFloat("Horizontal_Run", Orientation.x);

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, target.position) <= stoppingDistance)
            {
                Attack = true;
            }

        }
        else
        {
            Enemy_Animator.SetFloat("Vertical_Run", 0);
            Enemy_Animator.SetFloat("Horizontal_Run", 0);
        }

    }
    void orientation_Enemy()
    {
        Orientation = transform.position - target.transform.position;

        if (Orientation.x >= 1)
        {
            Orientation.x = -1;
        }
        else if (Orientation.x <= -1)
        {
            Orientation.x = 1;
        }

        if (Orientation.y >= 1)
        {
            Orientation.y = -1;
        }
        else if (Orientation.y <= -1)
        {
            Orientation.y = 1;
        }

    }

    public void idle_Enemy()
    {
        switch (Orientation.y)
        {
            case 1:
                Enemy_Animator.SetFloat("Vertical_Idle", 1);
                Enemy_Animator.SetFloat("Horizontal_Idle", 0);
                break;
            case -1:
                Enemy_Animator.SetFloat("Vertical_Idle", -1);
                Enemy_Animator.SetFloat("Horizontal_Idle", 0);
                break;
            default: break;
        }

        switch (Orientation.x)
        {
            case 1:
                Enemy_Animator.SetFloat("Horizontal_Idle", 1);
                Enemy_Animator.SetFloat("Vertical_Idle", 0);
                break;
            case -1:
                Enemy_Animator.SetFloat("Horizontal_Idle", -1);
                Enemy_Animator.SetFloat("Vertical_Idle", 0);
                break;
            default: break;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.localPosition, Follow_Limit);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.localPosition, stoppingDistance);
    }



}
