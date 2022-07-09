using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : SingletonBehavior<SceneController>
{
    [SerializeField] private GameObject loginScene;
    [SerializeField] private GameObject menuScene;
    [SerializeField] private GameObject winScene;
    [SerializeField] private GameObject endScene;
    [SerializeField] private GameObject gameScene;
    [SerializeField] private GameObject gameOver;

    private void OnEnable()
    {
        ShowLogin();
    }

    public void HideAllScene()
    {
        loginScene.SetActive(false);
        menuScene.SetActive(false);
        winScene.SetActive(false);
        endScene.SetActive(false);
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
