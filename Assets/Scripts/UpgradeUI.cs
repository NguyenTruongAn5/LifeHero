using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private Text m_txtInfoTime;
    [SerializeField] private Text m_txtInfoPower;
    [SerializeField] private Text m_txtInfoMoney;

    [SerializeField] private Text m_txtPiceTime;
    [SerializeField] private Text m_txtPicePower;
    [SerializeField] private Text m_txtPiceMoney;

    [SerializeField] private Button m_btnTime;
    [SerializeField] private Button m_btnPower;
    [SerializeField] private Button m_btnMoney;
    [SerializeField] private Button m_btnCloseUpGrade;

    [SerializeField] private GameObject m_pannelUpgrade;

    private void Start()
    {
        LoadComponent();
        SetValueInfo();
    }
    private void Reset()
    {
        LoadComponent();
    }

    private void SetValueInfo()
    {
        if (m_txtPiceTime == null || m_txtPicePower == null || m_txtPiceMoney == null
            || m_txtInfoTime == null || m_txtInfoPower == null || m_txtInfoMoney == null) return;
        m_txtInfoTime.text = GameManager.Instance.GetUpTime() + " % of offline";
        m_txtInfoPower.text = "up " + GameManager.Instance.GetUpPower() + "power when sell";
        m_txtInfoMoney.text = GameManager.Instance.GetUpMoney() + " % off power to money";

        m_txtPiceMoney.text = GameManager.Instance.GetPriceMoney().ToString();
        m_txtPicePower.text = GameManager.Instance.GetPricePower().ToString();
        m_txtPiceTime.text = GameManager.Instance.GetPriceTime().ToString();
    }

    private void LoadComponent()
    {
        m_txtInfoMoney = GameObject.Find("txt_MoneyInfo").GetComponent<Text>();
        m_txtInfoTime = GameObject.Find("txt_timeInfo").GetComponent<Text>();
        m_txtInfoPower = GameObject.Find("txt_PowerInfo").GetComponent<Text>();

        m_txtPiceMoney = GameObject.Find("txtPriceMoney").GetComponent<Text>();
        m_txtPicePower = GameObject.Find("txtPricePower").GetComponent<Text>();
        m_txtPiceTime = GameObject.Find("txtPriceTime").GetComponent<Text>();

        m_btnTime = GameObject.Find("btnBuyTime").GetComponent<Button>();
        m_btnMoney = GameObject.Find("btnBuyMoney").GetComponent<Button>();
        m_btnPower = GameObject.Find("btnBuyPower").GetComponent<Button>();

        m_btnCloseUpGrade = GameObject.Find("btn_CloseUpGrade").GetComponent<Button>();

        m_btnCloseUpGrade.onClick.RemoveAllListeners();
        m_btnCloseUpGrade.onClick.AddListener(OnClickCloseUpgrade);

        m_btnPower.onClick.RemoveAllListeners();
        m_btnPower.onClick.AddListener(OnClickUpgarePower);

        m_btnMoney.onClick.RemoveAllListeners();
        m_btnMoney.onClick.AddListener(OnClickUpgareMoney);

        m_btnTime.onClick.RemoveAllListeners();
        m_btnTime.onClick.AddListener(OnClickUpgareTime);
    }
    private void OnClickCloseUpgrade()
    {
        if (m_pannelUpgrade == null) return;
        m_pannelUpgrade.gameObject.SetActive(false);
    }
    private void OnClickUpgareTime()
    {
        if (m_txtInfoTime == null) return;
        int money = GameManager.Instance.GetCoin();
        int priceTime = GameManager.Instance.GetPriceTime();
        if (money - priceTime >= 0)
        {
            GameManager.Instance.SetDownCoin(priceTime);
            float curentUpTime = GameManager.Instance.GetUpTime() * 100;
            GameManager.Instance.SetUpTime(0.01f);
            m_txtInfoTime.text = "up" + curentUpTime.ToString() + " % off offline";
            GameManager.Instance.SetPriceTime();
            m_txtPiceTime.text = priceTime.ToString();
            UpdateUI.Instance.UpdateTxtMoney();
        }
        else
        {
            ShowCloseUI.Instance.OnClickShowInfo();
            Debug.Log("Ban het tien" );
        }
    }

    private void OnClickUpgareMoney()
    {
        if (m_txtInfoMoney == null) return;
        int money = GameManager.Instance.GetCoin();
        int priceMoney = GameManager.Instance.GetPriceMoney();
        if (money - priceMoney >= 0)
        {
            GameManager.Instance.SetDownCoin(priceMoney);
            float curentUpTime = GameManager.Instance.GetUpMoney() * 100;
            GameManager.Instance.SetUpMoney(0.01f);
            m_txtInfoMoney.text = curentUpTime.ToString() + "power when sell";
            GameManager.Instance.SetPriceMoney();
            m_txtPiceTime.text = priceMoney.ToString();
            UpdateUI.Instance.UpdateTxtMoney();
        }
        else
        {
            ShowCloseUI.Instance.OnClickShowInfo();
            Debug.Log("Ban het tien");
        }
    }

    private void OnClickUpgarePower()
    {
        if (m_txtPicePower == null) return;
        int money = GameManager.Instance.GetCoin();
        int pricePower = GameManager.Instance.GetPricePower();
        if (money - pricePower >= 0)
        {
            GameManager.Instance.SetDownCoin(pricePower);
            float curentUpPower = GameManager.Instance.GetUpPower() * 100;
            GameManager.Instance.SetUpPower(0.01f);
            m_txtInfoPower.text = curentUpPower.ToString() + "% off power to money";
            GameManager.Instance.SetPricePower();
            m_txtPicePower.text = pricePower.ToString();
            UpdateUI.Instance.UpdateTxtMoney();
        }
        else
        {
            ShowCloseUI.Instance.OnClickShowInfo();
            Debug.Log("Ban het tien");
        }
    }
}
