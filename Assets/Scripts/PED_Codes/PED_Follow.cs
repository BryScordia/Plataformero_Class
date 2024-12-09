using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PED_Follow : MonoBehaviour
{
    public Coins_System System;
    public Animator PED_Animator;

    public float speed;
    public float stoppingDistance;
    public float Follow_Limit;

    private Transform target;
    public Vector2 Orientation;

    public int PED_Status = 1;



    private Rigidbody2D RigidB;
    private Vector2 moveVel;

    public DeathSound deathSound;

    void Start()
    {
        RigidB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        switch (PED_Status)
        {
            case 1:
                PED_Follow_Player();
                break;
            case 2:
                StartCoroutine(PED_Death());
                break;
            default:
                break;
        }
    }

    IEnumerator PED_Death()
    {
        PED_Animator.SetBool("Death", true);

        if (deathSound != null)
        {
            deathSound.PlayDeathSound();
        }

        yield return new WaitForSeconds(.4f);
        System.Timer += 5;
        System.Add_Points(2, 1);
        Destroy(gameObject);
    }



    public void PED_Follow_Player()
    {

        orientation_PED();
        idle_PED();

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance && Vector2.Distance(transform.position, target.position) < Follow_Limit)
        {
            PED_Animator.SetFloat("Vertical_Run", Orientation.y);
            PED_Animator.SetFloat("Horizontal_Run", Orientation.x);

            Vector2 MoveInput = new Vector2(Orientation.x, Orientation.y);
            moveVel = MoveInput.normalized * speed;
            RigidB.MovePosition(RigidB.position + moveVel * Time.fixedDeltaTime);
        }
        else
        {
            PED_Animator.SetFloat("Vertical_Run", 0);
            PED_Animator.SetFloat("Horizontal_Run", 0);
        }

    }
    void orientation_PED()
    {
        Orientation = transform.position - target.transform.position;

        if (Orientation.x >= 1)
        {
            Orientation.x = 1;
        }
        else if (Orientation.x <= -1)
        {
            Orientation.x = -1;
        }

        if (Orientation.y >= 1)
        {
            Orientation.y = 1;
        }
        else if (Orientation.y <= -1)
        {
            Orientation.y = -1;
        }

    }

    public void idle_PED()
    {
        switch (Orientation.y)
        {
            case 1:
                PED_Animator.SetFloat("Vertical_Idle", 1);
                PED_Animator.SetFloat("Horizontal_Idle", 0);
                break;
            case -1:
                PED_Animator.SetFloat("Vertical_Idle", -1);
                PED_Animator.SetFloat("Horizontal_Idle", 0);
                break;
            default: break;
        }

        switch (Orientation.x)
        {
            case 1:
                PED_Animator.SetFloat("Horizontal_Idle", 1);
                PED_Animator.SetFloat("Vertical_Idle", 0);
                break;
            case -1:
                PED_Animator.SetFloat("Horizontal_Idle", -1);
                PED_Animator.SetFloat("Vertical_Idle", 0);
                break;
            default: break;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.localPosition, Follow_Limit);
    }

}
