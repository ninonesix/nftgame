using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnd : MonoBehaviour
{
    private void Awake()
    {
        GameManager.OnGameOver += DestroyObject;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= DestroyObject;    
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
