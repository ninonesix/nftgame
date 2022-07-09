using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeAlarm : MonoBehaviour
{
    [SerializeField] PipeController controller;

    private void OnBecameInvisible()
    {
        controller.OnMoveOutOfCamera();
    }
}
