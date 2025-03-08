using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataReader : MonoBehaviour
{
    public GameManager manager;
    public TextMeshProUGUI[] boardBoxes;
    public TextMeshProUGUI yourScore;
    public TextMeshProUGUI otherdScore;
    public TextMeshProUGUI round;

    private void OnEnable()
    {
        manager.onGotData += UpdateBoard;
    }

    private void OnDisable()
    {
        manager.onGotData -= UpdateBoard;
    }

    public void UpdateBoard()
    {
        for (int i = 0; i < manager.data.board.Length; i++)
        {
            if (manager.data.board[i] == 1)
            {
                //cambiar texto en el boton a X
            }
            else if (manager.data.board[i] == 1)
            {
                //cambiar texto en el boton a O
            }
            else
            {
                //Dejar el texto en el boton vacio
            }
        }
        UpdateScore();
    }

    public void UpdateScore()
    {
        if(manager.id == "&id=id1")
        {
            //cambiar texto yourScore con manager.data.score1
            //cambiar texto otherScore con manager.data.score2
        }
        else if(manager.id == "&id=id2")
        {
            //cambiar texto yourScore con manager.data.score2
            //cambiar texto otherScore con manager.data.score1
        }
        //cambiar texto round con manager.data.round
    }
}
