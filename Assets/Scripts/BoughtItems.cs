using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoughtItems : MonoBehaviour
{
    [SerializeField] private Button m_btn_CLick;
    [SerializeField] private Button m_btn_CLickBoughtOne;
    [SerializeField] private Button m_btn_CLickBoughtTwo;
    [SerializeField] private Button m_btn_PriceOne;

    [SerializeField] private ListDataItems m_ListDataItem;

    private void Start()
    {
        LoadComponent();
        SetInfoBtnClick();
        SetInfoBtnOne();
        SetInfoBtnTwo();
    }

    private void LoadComponent()
    {
        m_btn_CLick = GameObject.Find("btn_Click").GetComponent<Button>();
        m_btn_CLickBoughtOne = GameObject.Find("btn_NextOne").GetComponent<Button>();
        m_btn_CLickBoughtTwo = GameObject.Find("btn_NextTwo").GetComponent<Button>();
    }

    private void SetInfoBtnClick()
    {
        Text[] txt_Array = m_btn_CLick.GetComponentsInChildren<Text>();
        int index = GameManager.Instance.GetIndex();
        if (txt_Array[0] == null || txt_Array[1] == null || m_ListDataItem == null) return;
        txt_Array[0].text = m_ListDataItem.m_LisDataItems[index].m_NameItem;
        txt_Array[1].text = m_ListDataItem.m_LisDataItems[index].m_Power.ToString();
    }
    private void SetInfoBtnOne()
    {
        Text[] txt_Array = m_btn_CLickBoughtOne.GetComponentsInChildren<Text>();
        int index = GameManager.Instance.GetIndex();
        if (txt_Array[0] == null || txt_Array[1] == null || m_ListDataItem == null) return;
        txt_Array[0].text = m_ListDataItem.m_LisDataItems[index+1].m_NameItem;
        txt_Array[1].text = m_ListDataItem.m_LisDataItems[index+1].m_Power.ToString();

        Button btn_Price = GameObject.FindGameObjectWithTag(ManagerTag.m_btn_price_One)
            .GetComponent<Button>();
        int newIndex = index + 1;
        int price = m_ListDataItem.m_LisDataItems[newIndex].m_Dola;
        Text txt_Price = btn_Price.GetComponentInChildren<Text>();
        txt_Price.text = price.ToString();

        btn_Price.onClick.RemoveAllListeners();
        if ((index + 2) >= m_ListDataItem.m_LisDataItems.Count) return;
        btn_Price.onClick.AddListener(()=>OnClickBuy(price, newIndex));
    }

    private void OnClickBuy(int price, int index)
    {
        int coinPlayer = GameManager.Instance.GetCoin();
        if (coinPlayer - price >= 0)
        {
            GameManager.Instance.SetIndex(index);
            GameManager.Instance.SetDownCoin(price);
            SetInfoBtnOne();
            SetInfoBtnTwo();
            SetInfoBtnClick();
            CeatedItemModel.Instance.CreateItem(index);
        }
        else
        {
            ShowCloseUI.Instance.OnClickShowInfo();
            Debug.Log("ban chua du tien?");//Pop up UI
        } 
    }

    private void SetInfoBtnTwo()
    {
        Text[] txt_Array = m_btn_CLickBoughtTwo.GetComponentsInChildren<Text>();
        int index = GameManager.Instance.GetIndex();
        if (txt_Array[0] == null || txt_Array[1] == null || m_ListDataItem == null) return;
        if ((index + 2) >= m_ListDataItem.m_LisDataItems.Count) return;
        txt_Array[0].text = m_ListDataItem.m_LisDataItems[index + 2].m_NameItem;
        txt_Array[1].text = m_ListDataItem.m_LisDataItems[index + 2].m_Power.ToString();
    }

    private void Reset()
    {
        LoadComponent();
    }
}
