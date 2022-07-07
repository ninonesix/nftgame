using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject pipeHolder;
    [SerializeField] private GameObject[] pipes;
    [SerializeField] private GameObject gameBG;
    [SerializeField] private GameObject land;
    [SerializeField] private Dictionary<GameObject, Vector2> objOrgPosition;

    private void Awake()
    {
        objOrgPosition = new Dictionary<GameObject, Vector2>();
        objOrgPosition.Add(character,character.transform.position);
        foreach(var pipe in pipes)
        {
            objOrgPosition.Add(pipe,pipe.transform.position);
        }
    }

    private void ResetAllPosition()
    {
        character.transform.position = GetGameObjectOrgPosition(character);
        foreach(var pipe in pipes)
        {
            pipe.transform.position = GetGameObjectOrgPosition(pipe);
        }
    }

    private Vector2 GetGameObjectOrgPosition(GameObject gobj)
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
        character.GetComponent<PlayerMove>().StartPlayer();
        foreach(var pipe in pipes)
        {
            pipe.GetComponent<Move>().StartMove();
        }
    }

    private void OnDisable()
    {
        character.GetComponent<PlayerMove>().StopPlayer();
        foreach(var pipe in pipes)
        {
            pipe.GetComponent<Move>().StopMove();
        }
    }
}
