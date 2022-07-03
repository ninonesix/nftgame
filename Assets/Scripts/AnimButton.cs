using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AnimButton : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private bool bounced;

    [SerializeField] private bool dropped;

    [SerializeField] private bool scaledOverTime;

    [Header("Timing")]
    //[SerializeField] private float fadeOutBounce = 0.1f;
    //[SerializeField] private float fadeInBounce = 0.1f;

    private Sequence seq;
    private Button btn;
    private RectTransform rect;
    private IEnumerator scaleOverTime;

    private void Awake()
    {
        btn = GetComponent<Button>();
        rect = GetComponent<RectTransform>();
        btn.onClick.AddListener(OnClickedAction);

        if(scaledOverTime)
        {
            var seq = DOTween.Sequence();
            seq.Append(transform.DOScale(1.2f, 0.3f));
            seq.Append(transform.DOScale(1f, 0.3f));
            seq.SetLoops(-1);
        }
    }

    private void OnClickedAction()
    {
        seq.Kill();
        seq = DOTween.Sequence();

        if (bounced)
        {
            seq.Append(transform.DOScale(0.9f, 0.1f));
            seq.Append(transform.DOScale(1f, 0.1f));
        }

        if (dropped)
        {
            var pos = rect.anchoredPosition;
            var start = pos + Vector2.down * 30f;
            seq.Insert(0, rect.DOAnchorPos(start, 0.15f));
            seq.Insert(0.15f, rect.DOAnchorPos(pos, 0.15f));
        }
    }
}