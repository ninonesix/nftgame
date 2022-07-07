using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    public float velocity = 1;
    private Rigidbody2D rb;
    public ManageGame ManageGame;
    private bool stop;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(stop)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Jump
            rb.velocity = Vector2.up * velocity;
        }
    }

    public void StopPlayer()
    {
        stop = true;
    }

    public void StartPlayer()
    {
        stop = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == Constants.PIPE_TAG)
        {
            SceneController.instance.ShowOver();
        }
        else if (collision.collider.tag == Constants.GOAL_TAG)
        {
            SceneController.instance.ShowWin();
        }
    }

}

