using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private bool stop;

    void Update()
    {
        if (stop)
        {
            return;
        }
        transform.position += Vector3.left * speed * Time.deltaTime;
        
    }

    public void StopMove()
    {
        stop = true;
    }

    public void StartMove()
    {
        stop = false;
    }
}
