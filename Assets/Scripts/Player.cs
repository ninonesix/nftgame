using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private float velocity = 1;
    private Rigidbody2D rb;
    private bool stop;

    void Awake()
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
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void StartPlayer()
    {
        stop = false;
        rb.constraints = RigidbodyConstraints2D.None;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == Constants.PIPE_TAG)
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

