using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Btn_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject _pannel;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Intro");
    }

    public void ReTryBtn()
    {
        SceneManager.LoadScene("Game");
    }

    public void HowToPlay()
    {
        _pannel.SetActive(true);
    }

    public void HowToPlayBack()
    {
        _pannel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
