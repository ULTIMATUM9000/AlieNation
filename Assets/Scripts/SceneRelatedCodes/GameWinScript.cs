using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinScript : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {
        YouWin();
    }

    public void YouWin()
    {
        SceneManager.LoadScene("_WinMenuScene");
    }

    
}
