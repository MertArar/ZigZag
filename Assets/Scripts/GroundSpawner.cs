using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroundSpawner : MonoBehaviour
{
    public GameObject lastGround;

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            GroundCreator();
        }
    }

    public void GroundCreator()
    {
        Vector3 direction;

        if (Random.Range(0,2) == 0)
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.forward;
        }

        lastGround = Instantiate(lastGround, lastGround.transform.position + direction, lastGround.transform.rotation);
    }
}
