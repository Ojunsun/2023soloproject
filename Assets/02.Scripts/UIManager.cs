using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text[] Title;
    [SerializeField] Text explanation;
    [SerializeField] Button[] _Btn;
    
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Invoke("Disable", 3f);
    }

    public void SeeUI()
    {
        Title[0].gameObject.SetActive(true);
        Title[1].gameObject.SetActive(true);
        _Btn[0].gameObject.SetActive(true);
        _Btn[1].gameObject.SetActive(true);
    }

    private void Disable()
    {
        explanation.gameObject.SetActive(false);
    }
}
