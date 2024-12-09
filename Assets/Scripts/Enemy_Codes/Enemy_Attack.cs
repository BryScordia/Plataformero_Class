using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public Enemy_Follow Enemy;
    public float Attack_Range;
    public LayerMask Player_Layer;
    public Transform Attack_Point;
    private bool Attack_Bool;


    // Update is called once per frame
    void Update()
    {
        Attack_Point_Position();
        if (Enemy.Attack)
        {
            StartCoroutine(Enemy_Cooldown());
        }
        else
        {
            Enemy.Enemy_Animator.ResetTrigger("Attack");
        }

    }

    void Attack()
    {

        Enemy.Enemy_Animator.SetTrigger("Attack");



        Collider2D[] hit_Enemies = Physics2D.OverlapCircleAll(Attack_Point.position, Attack_Range, Player_Layer);

        foreach (Collider2D Player in hit_Enemies)
        {
            Player.GetComponent<Player_Lifes>().Damage_Player();
        }

    }

    IEnumerator Enemy_Cooldown()
    {
        Attack();
        Enemy.Attack = false;
        yield return new WaitForSeconds(2F);
        Enemy.Attack = true;
    }


    void Attack_Point_Position()
    {
        Vector2 Ramon;

        switch (Enemy.Orientation.y)
        {
            case 1:
                Ramon = new Vector2(0, 1);
                Attack_Point.localPosition = Ramon;
                break;
            case -1:
                Ramon = new Vector2(0, -1);
                Attack_Point.localPosition = Ramon;
                break;
            default: break;
        }

        switch (Enemy.Orientation.x)
        {
            case 1:
                Ramon = new Vector2(1, 0);
                Attack_Point.localPosition = Ramon;
                break;
            case -1:
                Ramon = new Vector2(-1, 0);
                Attack_Point.localPosition = Ramon;
                break;
            default: break;
        }


    }

    private void OnDrawGizmosSelected()
    {
        if (Attack_Point == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(Attack_Point.position, Attack_Range);
    }

}
