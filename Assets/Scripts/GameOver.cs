using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    [SerializeField] private GameObject getReward;
    [SerializeField] private GameObject replay;

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

    private void OnEnable()
    {
        replay.SetActive(false);
        getReward.SetActive(true);
    }

    private void OnDisable()
    {
        replay.SetActive(false);
        getReward.SetActive(false);
    }

    public void OnGetReward()
    {
        getReward.SetActive(false);
        replay.SetActive(true);
    }
}
