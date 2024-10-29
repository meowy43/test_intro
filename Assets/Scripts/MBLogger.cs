using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBLogger : MonoBehaviour
{
    private void Awake()
    {
        Log("Awake");
    }
        private void Start()
    {
        Log("Start");
    }

    private void Log(string msg)
    {
        Debug.Log($"{gameObject.name}: msg - frame{Time.frameCount}");
    }
}
