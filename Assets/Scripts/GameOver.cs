using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    [SerializeField] private Button getReward;
    [SerializeField] private Button replay;
    [SerializeField] private Button menu;

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
        replay.gameObject.SetActive(false);
        menu.gameObject.SetActive(false); 
        getReward.gameObject.SetActive(true);
        replay.interactable = true;
        menu.interactable = true;
        getReward.interactable = true;
    }

    private void OnDisable()
    {
        replay.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        getReward.gameObject.SetActive(false);
    }

    public void OnGetReward()
    {
        getReward.interactable = false;
        getReward.gameObject.SetActive(false);
        replay.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
        GameManager.instance.ResetScore();
    }

    public void TurnOffInteractable(Button button)
    {
        button.interactable = false;
    }
}
