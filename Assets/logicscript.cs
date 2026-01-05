using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class logicscript : MonoBehaviour
{

    public int score1 = 0;
    public int score2 = 0;
    public Text stext;
    public Text otext;
    public Text wintext;
    public GameObject Pausemenu;
    public bool isPause = false;
    public static bool istwoplayer = false;
    public static int winner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void Awake()
    {
        
    }
    void Start()
    {
        Pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPause)  Resume();
            
            else  Pause();
        }
    }

    public void addScore(int p = 1, int x = 1)
    {
        if (p == 1)
        {
            score1 += x;
            stext.text = score1.ToString();
            if (score1 >= 50)
            {
                wingame(1);
            }
        }

        if (p == 2)   
        {
            score2 += x;
            otext.text = score2.ToString();
            if (score2 >= 50)
            {
                wingame(2);
            }
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Pause()
    {
        Pausemenu.SetActive(true);
        isPause = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Pausemenu.SetActive(false);
        isPause = false;
        Time.timeScale = 1f;
    }

    public void singleplayer()
    {
        istwoplayer = false;
        SceneManager.LoadScene("GameScene");
        
    }

    public void twoplayer()
    {
        istwoplayer = true;
        SceneManager.LoadScene("GameScene");
       
    }

    public void wingame(int x = 1)
    {
        winner = x;
        SceneManager.LoadScene("WinScene");
    }   


    public void Mainmenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void Quitgame()
    {
        Application.Quit();
    }
}
