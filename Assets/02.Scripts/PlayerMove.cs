using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float hAxis;
    float vAxis;

    float speed = 10f;
    float rotateSpeed = 15f;
    Vector3 fb = new Vector3(0, 0, 1);
    Vector3 lb = new Vector3(0, 1, 0);

    private void Update()
    {
        hAxis = Input.GetAxis("Horizontal") * Time.deltaTime;
        vAxis = Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(fb * vAxis * speed);
        transform.Rotate(lb * hAxis * rotateSpeed);
    }
}
