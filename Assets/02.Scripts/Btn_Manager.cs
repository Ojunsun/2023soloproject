using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_Manager : MonoBehaviour
{
    public void GoTitle()
    {
        SceneManager.LoadScene("Intro");
    }

    public void ReTryBtn()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
