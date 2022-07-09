using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : SingletonBehavior<GameManager>
{
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject pipeHolder;
    [SerializeField] private GameObject[] pipes;
    [SerializeField] private GameObject gameBG;
    [SerializeField] private GameObject land;
    [SerializeField] private Dictionary<GameObject, Vector2> objOrgPosition;

    public static float ScreenWidthSize;
    public static Vector2 RightBoundLimit;

    protected override void Awake()
    {
        base.Awake();
        objOrgPosition = new Dictionary<GameObject, Vector2>();
        objOrgPosition.Add(character,character.transform.position);
        foreach(var pipe in pipes)
        {
            objOrgPosition.Add(pipe,pipe.transform.position);
        }

        ScreenWidthSize = Camera.main.orthographicSize * 2f * Screen.width / Screen.height;

        RightBoundLimit = new Vector2(ScreenWidthSize / 2, 0);
    }

    private void ResetAllPosition()
    {
        character.transform.position = GetGameObjectOrgPosition(character);
        foreach(var pipe in pipes)
        {
            pipe.transform.position = GetGameObjectOrgPosition(pipe);
        }
    }

    public Vector2 GetGameObjectOrgPosition(GameObject gobj)
    {
        return objOrgPosition.ContainsKey(gobj) ? objOrgPosition[gobj] : Vector2.zero;
    }

    private void OnEnable()
    {
        ResetAllPosition();
        character.SetActive(true);
        pipeHolder.SetActive(true);
        gameBG.SetActive(true);
        land.SetActive(true);
        character.GetComponent<Player>().StartPlayer();
        foreach(var pipe in pipes)
        {
            pipe.GetComponent<PipeController>().StartMove();
        }
    }

    private void OnDisable()
    {
        character.GetComponent<Player>().StopPlayer();
        foreach(var pipe in pipes)
        {
            pipe.GetComponent<PipeController>().StopMove();
        }
    }
}
