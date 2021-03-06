using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneController : SingletonBehavior<SceneController>
{
    [SerializeField] private GameObject loginScene;
    [SerializeField] private GameObject menuScene;
    [SerializeField] private GameObject gameScene;
    [SerializeField] private GameObject gameOver;

    public static Action OnEnterGame;

    private void OnEnable()
    {
        ShowLogin();
    }

    public void HideAllScene()
    {
        loginScene.SetActive(false);
        menuScene.SetActive(false);
        gameOver.SetActive(false);
        gameScene.SetActive(false);
    }

    public void ShowLogin()
    {
        HideAllScene();
        loginScene.SetActive(true);
    }

    public void ShowGame()
    {
        HideAllScene();
        OnEnterGame?.Invoke();
        GameManager.instance?.ResetScore();
        gameScene.SetActive(true);
    }

    public void ShowMenu()
    {
        HideAllScene();
        menuScene.SetActive(true);
    }

    public void ShowOver()
    {
        HideAllScene();
        gameOver.SetActive(true);
    }
}
