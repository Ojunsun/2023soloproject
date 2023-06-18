using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text Title;
    [SerializeField] Button[] _Btn;
    public void SeeUI()
    {
        Title.gameObject.SetActive(true);
        _Btn[0].gameObject.SetActive(true);
        _Btn[1].gameObject.SetActive(true);
    }
}
