using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    [SerializeField] private GameObject Portal_Mark;
    public Player_Lifes Player_Status;
    private bool isPlayerInRange;

    public int Level_Selector;
    void Update()
    {

        if (isPlayerInRange && Input.GetButtonDown("Fire1"))
        {
            switch (Level_Selector)
            {
                case 1:
                    StartCoroutine(Load_Level("Level_1"));
                    break;
                case 2:
                    StartCoroutine(Load_Level("Level_2"));
                    break;
                case 3:
                    StartCoroutine(Load_Level("Level_3"));
                    break;
                case 4:
                    StartCoroutine(Load_Level("Ganaste"));
                    break;
                default:
                    StartCoroutine(Load_Level("Debug"));
                    break;
            }

        }

    }

    IEnumerator Load_Level(string Level)
    {
        Player_Status.Finish_Game();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(Level);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInRange = true;
            Portal_Mark.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInRange = false;
            Portal_Mark.SetActive(false);
        }
    }
}
