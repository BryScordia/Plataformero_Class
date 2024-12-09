using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed;
    public Animator Player_Animator;

    private Rigidbody2D RigidB;
    private Vector2 moveVel;

    public bool Lock_Controls;
    void Start()
    {
        RigidB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical_Custom"));
        if (!Lock_Controls)
        {
            idle_Player();
            Player_Animator.SetFloat("Vertical_Run", Input.GetAxisRaw("Vertical"));
            Player_Animator.SetFloat("Horizontal_Run", Input.GetAxisRaw("Horizontal"));
            moveVel = MoveInput.normalized * speed;
        }
        else
        {
            Player_Animator.SetFloat("Vertical_Run", 0);
            Player_Animator.SetFloat("Horizontal_Run", 0);
            moveVel = MoveInput.normalized * 0;
        }

        if (Input.GetKey(KeyCode.W)) Debug.Log("Tecla W presionada");
        if (Input.GetKey(KeyCode.S)) Debug.Log("Tecla S presionada");
        if (Input.GetKey(KeyCode.UpArrow)) Debug.Log("Flecha arriba presionada");
        if (Input.GetKey(KeyCode.DownArrow)) Debug.Log("Flecha abajo presionada");

    }

    void FixedUpdate()
    {
        RigidB.MovePosition(RigidB.position + moveVel * Time.fixedDeltaTime);    
    }


    public void idle_Player()
    {
        switch (Input.GetAxisRaw("Vertical"))
        {
            case 1:
                Player_Animator.SetFloat("Vertical_Idle", 1);
                Player_Animator.SetFloat("Horizontal_Idle", 0);
                break;
            case -1:
                Player_Animator.SetFloat("Vertical_Idle", -1);
                Player_Animator.SetFloat("Horizontal_Idle", 0);
                break;
            default: break;
        }

        switch (Input.GetAxisRaw("Horizontal"))
        {
            case 1:
                Player_Animator.SetFloat("Horizontal_Idle", 1);
                Player_Animator.SetFloat("Vertical_Idle", 0);
                break;
            case -1:
                Player_Animator.SetFloat("Horizontal_Idle", -1);
                Player_Animator.SetFloat("Vertical_Idle", 0);
                break;
            default: break;
        }
    }

}


