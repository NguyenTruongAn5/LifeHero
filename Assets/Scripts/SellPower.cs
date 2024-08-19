using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellPower : MonoBehaviour
{
    [SerializeField] private Button m_btn_Sell;
    [SerializeField] private Transform m_Player;
    [SerializeField] private Transform m_armLeft;
    [SerializeField] private Transform m_armRight;
    private void Start()
    {
        LoadComponent();
        LoadObj();
    }

    private void LoadObj()
    {
        m_armLeft = GameObject.FindGameObjectWithTag(ManagerTag.m_arm_Left).transform;
        m_armRight = GameObject.FindGameObjectWithTag(ManagerTag.m_arm_Right).transform;
        m_Player = GameObject.FindGameObjectWithTag(ManagerTag.m_player).transform;
    }

    private void LoadComponent()
    {
        m_btn_Sell = GameObject.Find("btn_Sell").GetComponent<Button>();
        if (m_btn_Sell == null) return;
        m_btn_Sell.onClick.RemoveAllListeners();
        m_btn_Sell.onClick.AddListener(OnClickBtnSell);
    }

    private void OnClickBtnSell()
    {
        AddPowerMoney.Instance.PowerToMoney();
        ResetLocalScale();
    }

    private void ResetLocalScale()
    {
        Vector3 scale = new Vector3(0.5f, 1f, 0.5f);
        m_Player.transform.localScale = Vector3.one;
        m_armLeft.transform.localScale = scale;
        m_armRight.transform.localScale = scale;
    }

    private void Reset()
    {
        m_btn_Sell = GameObject.Find("btn_Sell").GetComponent<Button>();
    }
}
