using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleText : MonoBehaviour
{
    private Transform _camPos;
    private Transform _playerPos;

    [SerializeField] private float _distance;

    private TextMeshPro _text;

    private void Start()
    {
        _text = GetComponent<TextMeshPro>();
        _camPos = Camera.main.transform;
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.LookAt(_camPos);

        if (Vector3.Distance(transform.position, _playerPos.position) <= _distance)
        {
            _text.alpha = 1;
        }
        else
        {
            _text.alpha = 0;
        }
    }
}
