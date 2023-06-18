using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject door;
    public GameObject yame;
    [SerializeField] DoorMove doormove;
    [SerializeField] UIManager _UiManager;

    Vector3 dir = new Vector3(0, 0, 2);
    
    void Update()
    {
        Debug.Log(Vector3.Distance(yame.transform.position, door.transform.position));
        if (Vector3.Distance(yame.transform.position, door.transform.position) > 7f)
        {
            MoveStop();
            doormove.DoorOpen();
            _UiManager.SeeUI();
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
