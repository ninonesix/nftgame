using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] pipes;
    private bool stop;


    void Update()
    {
        if (stop)
        {
            return;
        }
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void OnMoveOutOfCamera()
    {
        if(transform.localPosition.x > 0)
        {
            return;
        }
        transform.localPosition = GameManager.RightBoundLimit + Vector2.right * 1.85f + Vector2.up * transform.localPosition.y;
        RandomChangePipeDistance();
    }

    private void RandomChangePipeDistance()
    {
        pipes[0].transform.localPosition = new Vector2(pipes[0].transform.localPosition.x, Random.Range(-2.85f, 0.16f));
        pipes[1].transform.localPosition = new Vector2(pipes[1].transform.localPosition.x, Random.Range(8.55f, 11.82f));
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
