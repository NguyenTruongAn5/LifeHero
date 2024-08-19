using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoSingleton<CountDown>
{
    [SerializeField] private Image m_imgCountDown;
    private float m_timer;
    private float m_countDownTime = 2f;
    private bool m_isCountDown;

    private void Start()
    {
        LoadComponent();
    }
    private void Update()
    {
        ExcuCountDown();
    }
    private void ExcuCountDown()
    {
        if (m_imgCountDown == null) return;
        if (m_isCountDown)
        {
            m_timer -= Time.deltaTime;
            m_imgCountDown.fillAmount = m_timer / m_countDownTime;

            if(m_timer <= 0)
            {
                m_isCountDown = true;
                m_timer = 0;
            }
        }
    }
    public void StartCountDown()
    {
        m_timer = m_countDownTime;
        m_isCountDown = true;
    }
    private void LoadComponent()
    {
        m_imgCountDown = GameObject.FindGameObjectWithTag(ManagerTag.m_count_Down)
            .GetComponent<Image> ();
    }
}
