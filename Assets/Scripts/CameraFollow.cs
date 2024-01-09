using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerLocation;
    Vector3 gap;

    private void Start()
    {
        gap = transform.position - playerLocation.position;
    }

    private void Update()
    {
        if (PlayerMovement.isFall == false)
        {
            transform.position = playerLocation.position + gap;
        }
    }
}
