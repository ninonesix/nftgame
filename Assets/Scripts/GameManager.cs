using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : SingletonBehavior<GameManager>
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject pipeHolder;
    [SerializeField] private GameObject[] pipes;
    [SerializeField] private GameObject gameBG;
    [SerializeField] private GameObject land;
    [SerializeField] private Dictionary<GameObject, Vector2> objOrgPosition;
    [SerializeField] private GameObject bee;

    private IEnumerator spawnBee;
    public static float ScreenWidthSize;
    public static Vector2 RightBoundLimit;
    private int score;
    public static Action OnGameOver;
    public static float Time;

    public int Score
    {
        get { return score; }  
    }

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

    public void ResetScore()
    {
        score = 0;
    }

    private void OnEnable()
    {
        ResetAllPosition();
        UpdateScoreText();
        gameCanvas.SetActive(true);
        character.SetActive(true);
        pipeHolder.SetActive(true);
        gameBG.SetActive(true);
        land.SetActive(true);
        character.GetComponent<Player>().StartPlayer();
        foreach(var pipe in pipes)
        {
            pipe.GetComponent<PipeController>().StartMove();
        }
        spawnBee = CoroutineSpawnBee();
        StartCoroutine(spawnBee);
    }

    private void OnDisable()
    {
        Time = 0f;
        OnGameOver?.Invoke();
        StopCoroutine(spawnBee);
        character.GetComponent<Player>().StopPlayer();
        foreach(var pipe in pipes)
        {
            pipe.GetComponent<PipeController>().StopMove();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(bool notify = true)
    {
        score += 1;
        if(notify)
        {
            UpdateScoreText();
        }
    }

    private IEnumerator CoroutineSpawnBee()
    {
        while(true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 2f));
            Instantiate(bee, new Vector3(ScreenWidthSize + 0.5f, UnityEngine.Random.Range(-3f, 4f), 0), Quaternion.identity);
        }
    }

    private void Update()
    {
        Time += UnityEngine.Time.deltaTime;
        Debug.Log("time is" + Time);
    }
}
