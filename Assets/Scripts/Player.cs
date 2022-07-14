using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float velocity = 1;
    private Rigidbody2D rb;
    private bool stop;
    private const float duration = 1.0f;
    private float time;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(stop)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) 
        {
            //Jump
            rb.velocity = Vector2.up * velocity;
        }

        if(Input.GetKeyDown(KeyCode.Return) && time > duration)
        {
            Instantiate(fireBall,transform.position,Quaternion.identity);
            time = 0;
        }
    }

    public void StopPlayer()
    {
        stop = true;
        time = 0f;
        //rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void StartPlayer()
    {
        stop = false;
        //rb.constraints = RigidbodyConstraints2D.None;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == Constants.PIPE_TAG)
        {
            SceneController.instance.ShowOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Constants.ENEMY))
        {
            SceneController.instance.ShowOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Constants.SCORE_ZONE_TAG))
        {
            GameManager.instance.IncreaseScore();
        }
    }

}

