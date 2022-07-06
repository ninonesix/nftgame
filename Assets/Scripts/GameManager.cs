using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject pipes;
    [SerializeField] private GameObject gameBG;
    [SerializeField] private GameObject land;

    private void OnEnable()
    {
        character.SetActive(true);
        pipes.SetActive(true);
        gameBG.SetActive(true);
        land.SetActive(true);
    }

    private void OnDisable()
    {
        
    }
}
