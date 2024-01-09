using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GroundSpawner groundSpawner;
    public static bool isFall;
    public float deleteTime = 3f;
    public float speed;
    public float increaseSpeed = 2f;
    Vector3 direction;

    private void Start()
    {
        direction = Vector3.forward;
        isFall = false;
    }

    private void Update()
    {
        if (transform.position.y <= 0.5f)
        {
            isFall = true;
        }

        if (isFall == true)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            if (direction.x == 0)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }

            speed = speed + increaseSpeed * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = direction * Time.deltaTime * speed;
        transform.position += movement;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Score.score++;
            collision.gameObject.AddComponent<Rigidbody>();
            groundSpawner.GroundCreator();
            StartCoroutine(DeleteGround(collision.gameObject));
        }
    }

    IEnumerator DeleteGround(GameObject deletedGround)
    {
        yield return new WaitForSeconds(deleteTime);
        Destroy(deletedGround);
    }
}
