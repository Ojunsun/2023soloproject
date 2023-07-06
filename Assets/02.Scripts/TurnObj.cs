using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObj : MonoBehaviour
{
    // Start is called before the first frame update
    float randRot;
    void Start()
    {
        InvokeRepeating("Rand", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(randRot, randRot, randRot);
    }

    void Rand()
    {
        randRot = Random.Range(.025f, .1f);
    }
}
