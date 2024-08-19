using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMessNPC : MonoBehaviour
{
    /*[SerializeField] private TextMesh m_txt_MessNPC;
    [SerializeField] private GameObject m_pannelNPC;

    private List<string> m_Message;
    float timer;
    float totalTime = 5f;

    private void Start()
    {
        LoadComponent();
        InitializeMessages();
        timer = totalTime;
    }

    private void Reset()
    {
        LoadComponent();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ShowMessageNPC();
            timer = totalTime;
        }
    }

    private void ShowMessageNPC()
    {
        if (m_txt_MessNPC == null || m_pannelNPC == null) return;

        m_pannelNPC.SetActive(true);
        int index = UnityEngine.Random.Range(0, m_Message.Count); 
        m_txt_MessNPC.text = m_Message[index];

        StartCoroutine(HidePannelAfterTime(2f)); 
    }

    private IEnumerator HidePannelAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        m_pannelNPC.SetActive(false);
    }

    private void LoadComponent()
    {
        if (m_txt_MessNPC == null)
        {
            m_txt_MessNPC = GameObject.FindGameObjectWithTag(ManagerTag.m_txtNPC)
                .GetComponent<TextMesh>();
        }

        if (m_pannelNPC == null)
        {
            m_pannelNPC = GameObject.FindGameObjectWithTag(ManagerTag.m_PannelNPC);
        }
    }

    private void InitializeMessages()
    {
        m_Message = new List<string>
        {
            "Keep pushing your limits!",
            "You're getting stronger every day!",
            "Great work, keep it up!",
            "Consistency is key, keep going!",
            "Your hard work is paying off!"
        };
    }*/
}
