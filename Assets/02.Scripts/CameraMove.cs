using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject door;
    public GameObject yame;
    [SerializeField] DoorMove doormove;
    [SerializeField] UIManager _UiManager;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;
    [SerializeField] GameObject Bgm;
    [SerializeField] GameObject Bgm2;
    Vector3 dir = new Vector3(0, 0, 2);

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Vector3.Distance(yame.transform.position, door.transform.position) > 7f)
        {
            _audioSource.PlayOneShot(_audioClip);
            MoveStop();
            doormove.DoorOpen();
            _UiManager.SeeUI();
            Bgm.SetActive(false);
            Bgm2.SetActive(true);
        }
        else
        {
            transform.position += dir * Time.deltaTime;
        }
    }

    void MoveStop()
    {
        dir = Vector3.zero;
        transform.position += dir * Time.deltaTime;
    }
}
