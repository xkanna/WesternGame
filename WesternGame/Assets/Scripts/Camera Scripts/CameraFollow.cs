using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform cowboyTransform;

    void Start()
    {
        cowboyTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 currentposition = transform.position;

        currentposition.x = cowboyTransform.position.x;
        currentposition.y = cowboyTransform.position.y;

        transform.position = currentposition;
    }
}
