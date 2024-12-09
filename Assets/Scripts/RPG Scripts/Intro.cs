using System.Collections;
using UnityEngine;
using TMPro;

public class Intro : MonoBehaviour
{
    public Level_Selector Level;
    public string Level_Selection;

    [SerializeField] private GameObject Dialogue_Panel;
    [SerializeField] private TMP_Text Dialogue_Text;
    [SerializeField, TextArea(4,6)] private string[] Dialogue_Lines;

    private float Typing_Time = 0.005f;
    
    private bool First_Time = true;
    public bool DidDialogueStart;
    private int Line_Index;

    void Update()
    {


        if (Input.GetButtonDown("Fire1") || First_Time)
        {
            First_Time = false;
            if (!DidDialogueStart)
            {
                Start_Dialogue();
            }
            else if (Dialogue_Text.text == Dialogue_Lines[Line_Index]){
                Next_Dialogue_Line();
            }

        }        
    }

    private void Start_Dialogue()
    {
        DidDialogueStart = true;
        Dialogue_Panel.SetActive(true);
        Line_Index = 0;
        StartCoroutine(Show_Line());
    }

    private void Next_Dialogue_Line()
    {
        Line_Index++;
        if (Line_Index < Dialogue_Lines.Length)
        {
            StartCoroutine(Show_Line());
        }
        else
        {
            DidDialogueStart = false;
            Dialogue_Panel.SetActive(false);
            Level.Load_Levels(Level_Selection);
        }
    }

    private IEnumerator Show_Line()
    {
        Dialogue_Text.text = string.Empty;
        foreach(char Ch in Dialogue_Lines[Line_Index])
        {
            Dialogue_Text.text += Ch;
            yield return new WaitForSeconds(Typing_Time);        
        }
    }
}
