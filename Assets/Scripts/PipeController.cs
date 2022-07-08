using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float speed;
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
        transform.position = GameManager.instance.GetGameObjectOrgPosition(gameObject) + Vector2.right * GameManager.ScreenSize;
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
