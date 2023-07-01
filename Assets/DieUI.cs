using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieUI : MonoBehaviour
{
    [SerializeField] Text[] Title;
    [SerializeField] Button[] _Btn;

    private void Start()
    {
        Invoke("SeeUI", 1f);
    }

    public void SeeUI()
    {
        Title[0].gameObject.SetActive(true);
        Title[1].gameObject.SetActive(true);
        _Btn[0].gameObject.SetActive(true);
        _Btn[1].gameObject.SetActive(true);
    }
}
