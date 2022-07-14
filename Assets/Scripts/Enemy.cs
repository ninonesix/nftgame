using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float speed;
    [SerializeField] private TextMeshProUGUI textLife;
    private bool stop;

    public void IncreaseHealth(int amount)
    {
        health += amount;
        textLife.text = health.ToString();
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        health = (int)(Mathf.Clamp(GameManager.Time / 15f, 1, 50));
        textLife.text = health.ToString();
        GameManager.OnGameOver += OnGameOver;
        SceneController.OnEnterGame += OnEnterGame;
        textLife.text = health.ToString();
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameOver;
        SceneController.OnEnterGame -= OnEnterGame; 
    }

    private void OnGameOver()
    {
        stop = true;
    }

    private void OnEnterGame()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (stop)
        {
            return;
        }
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        if(transform.position.x < 0)
        {
            Destroy(gameObject);
        }
    }
}
