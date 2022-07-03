using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SimpleMovein : MonoBehaviour
{
    [SerializeField] private Vector2 targetPosition;
    private RectTransform body;

    private void Awake()
    {
        body = GetComponent<RectTransform>();
    }
    void Start()
    {
        body.DOAnchorPos(targetPosition, 0.5f);
    }
}
