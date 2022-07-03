using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : SingletonBehavior<SceneController>
{
    [SerializeField] private GameObject loginScene;
    [SerializeField] private GameObject menuScene;
    [SerializeField] private GameObject winScene;
    [SerializeField] private GameObject endScene;
    //[SerializeField] private GameObject gameScene;

    public void HideAllScene()
    {
        loginScene.SetActive(false);
        menuScene.SetActive(false);
        winScene.SetActive(false);
        endScene.SetActive(false);
        //gameScene.SetActive(false);
    }

    public void ShowGame()
    {

    }

    public void ShowMenu()
    {
        HideAllScene();
        menuScene.SetActive(true);
    }

    public void ShowWin()
    {

    }

    public void ShowEnd()
    {

    }
}
