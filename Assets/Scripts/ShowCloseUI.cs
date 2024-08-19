using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCloseUI : MonoSingleton<ShowCloseUI>
{
    [SerializeField] private Button m_btn_Close;
    [SerializeField] private GameObject pannel;
    private void Start()
    {
       pannel.SetActive(false);
    }

    public void OnClickClose()
    {
        if(pannel == null) return;
        pannel.SetActive(false);
        Debug.Log("Da chay");
    }
    public void OnClickShowInfo()
    {
        if (pannel == null) return;
        pannel.SetActive(true);
    }
}
