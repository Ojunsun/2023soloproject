using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public float speed = 2;
    public void DoorOpen()
    {
        transform.Translate(new Vector3(0,0,-10) * speed * Time.deltaTime);
    }
}
