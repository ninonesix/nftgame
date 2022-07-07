using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponent<Canvas>();
        transform.DOScale(0f, 0f);
    }

    private void Start()
    {
        transform.DOScale(1f, 0.7f);
    }
}
