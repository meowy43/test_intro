using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmCheck : MonoBehaviour
{

    public event System.Action onBeatGood;
    public event System.Action onBeatMid;
    public event System.Action onBeatBad;
    public float offsetMax = 0.320f;
    public float offsetMid = 0.180f;
    private bool m_checkingOngoing = false;
    private bool m_inputDetected = false;
    private float m_timer;
    private float startTime;
    private float perfectBeatTime;

    void Update()
    {
        if (m_checkingOngoing)
        {
            
            if (m_inputDetected)
            {
                if (Mathf.Abs(m_timer - perfectBeatTime) < offsetMax)
                {
                    if (Mathf.Abs(m_timer - perfectBeatTime) < offsetMid)
                    {
                        m_checkingOngoing = false;
                        m_inputDetected = false;
                        onBeatGood?.Invoke();
                        return;
                    }
                    m_checkingOngoing = false;
                    m_inputDetected = false;
                    onBeatMid?.Invoke();
                }
                else
                {
                    m_checkingOngoing = false;
                    m_inputDetected = false;
                    onBeatBad?.Invoke();
                }
            }

            m_timer = (float)AudioSettings.dspTime;

            if (m_timer - startTime > offsetMax * 2)
            {
                m_checkingOngoing = false;
                m_inputDetected = false;
                onBeatBad?.Invoke();
            }
        }

    }
    public void InputDown()
    {
        m_inputDetected = true;
    }
    public void InputUp()
    {
        m_inputDetected = false;
    }

    public void CheckStart()
    {
        m_checkingOngoing = true;
        startTime = (float)AudioSettings.dspTime;
        perfectBeatTime = startTime + offsetMax;
    }
}
