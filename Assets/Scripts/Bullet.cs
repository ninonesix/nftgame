using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float endDuration = 4f;
    private float duration;

    private void Awake()
    {
        GameManager.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameOver;   
    }

    private void OnGameOver()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        duration += Time.deltaTime;
        transform.position += Vector3.right * speed * Time.deltaTime;
        if(duration > endDuration)
        {
            OnGameOver();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(Constants.ENEMY))
        {
            if(impactEffect!= null)
            {
                Instantiate(impactEffect, transform.position + Vector3.right * 0.5f + Vector3.down * 0.2f, Quaternion.identity);
            }
            collision.gameObject.GetComponent<Enemy>().IncreaseHealth(-1*damage);
            Destroy(gameObject);
        }
    }
}
