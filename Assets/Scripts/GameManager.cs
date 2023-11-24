using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public int memories = 0;
    public TMP_Text memoriesText;

    public void GetMemory()
    {
        memories++;


        if (memories.ToString().Length == 1)
        {
            memoriesText.text = "x " + memories.ToString() + " / 3";
        }
    }

    public void WinGame()
    {
        if (memories == 3)
        {
            Debug.Log("Fim de Jogo!");
        }
    }
}
