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
    [SerializeField] private GameObject leaderBoard;

    public static Action OnEnterGame;

    private void OnEnable()
    {
        ShowLogin();
    }

    public void ShowLeaderboard()
    {
        HideAllScene();
        leaderBoard.SetActive(true);
    }

    public void HideAllScene()
    {
        loginScene.SetActive(false);
        menuScene.SetActive(false);
        gameOver.SetActive(false);
        gameScene.SetActive(false);
        leaderBoard.SetActive(false);
    }

    public void ShowLogin()
    {
        HideAllScene();
        loginScene.SetActive(true);
    }

    public void ShowGame()
    {
        HideAllScene();
        GameManager.instance?.ResetScore();
        OnEnterGame?.Invoke();
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
