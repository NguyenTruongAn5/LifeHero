using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private int m_Coin = 100;
    [SerializeField] private int m_Power = 0;
    [SerializeField] private int m_Index = 0;
    [SerializeField] private int m_CurrentScore = 0;
    [SerializeField] private int m_HighScore = 0;
    [SerializeField] private float m_UpTime = 0f;
    [SerializeField] private float m_UpMoney = 0f;
    [SerializeField] private float m_UpPower = 0f;

    [SerializeField] private int m_OriginalPriceTime = 1500;
    [SerializeField] private int m_OriginalPricePower = 1500;
    [SerializeField] private int m_OriginalPriceMoney = 1500;
    private void Start()
    {
        /*SaveCoin(0);
        SaveCurrentScore(0);
        SetHighScore(0);
        SaveIndex(0);
        SavePower(0);
        SetPriceTime();*/
    }
    public void SetPriceTime()
    {
        m_OriginalPriceTime +=(int) (m_OriginalPriceTime * 1.2f);
        PrefabsData.PriceTime = m_OriginalPriceTime;
    }
    public int GetPriceTime()
    {
        m_OriginalPriceTime = PrefabsData.PriceTime;
        return m_OriginalPriceTime;
    }
    public void SetPricePower()
    {
        m_OriginalPricePower += (int)(m_OriginalPricePower * 1.2f);
        PrefabsData.PricePower = m_OriginalPricePower;
    }
    public int GetPricePower()
    {
        m_OriginalPricePower = PrefabsData.PricePower;
        return m_OriginalPricePower;
    }
    public void SetPriceMoney()
    {
        m_OriginalPriceMoney += (int)(m_OriginalPriceMoney * 1.2f);
        PrefabsData.PriceMoney = m_OriginalPriceMoney;
    }
    public int GetPriceMoney()
    {
        m_OriginalPriceMoney = PrefabsData.PriceMoney;
        return m_OriginalPriceMoney;
    }
    public void SetUpTime(float value)
    {
        m_UpTime += Mathf.Clamp(value, 0f, 0.5f);
        PrefabsData.UpTime = m_UpTime;
    }

    public void SetUpMoney(float value)
    {
        m_UpMoney += Mathf.Clamp(value, 0f, 0.5f);
        PrefabsData.UpMoney = m_UpMoney;
    }
    public float GetUpTime()
    {
        m_UpTime = PrefabsData.UpTime;
        return m_UpTime;
    }
    public float GetUpPower()
    {
        m_UpPower = PrefabsData.UpPower;
        return m_UpPower;
    }
    public float GetUpMoney()
    {
        m_UpMoney = PrefabsData.UpMoney;
        return m_UpMoney;
    }
    public void SetUpPower(float value)
    {
        m_UpPower += Mathf.Clamp(value, 0f, 0.5f);
        PrefabsData.UpPower = m_UpPower;
    }
    private void SaveCoin(int coin)
    {
        PrefabsData.Coin = coin;
    }
    private void SavePower(int power)
    {
        PrefabsData.Power = power;
    }
    private void SaveHighScore(int highScore)
    {
        PrefabsData.HighSore = highScore;
    }
    private void SaveIndex(int index)
    {
        PrefabsData.CurrentIndex = index;
    }
    private void SaveCurrentScore(int curScore)
    {
        PrefabsData.CurrentScore = curScore;
    }
    public void SetHighScore(int highScore)
    {
        m_HighScore = highScore;
        SaveHighScore(m_HighScore);
    }
    public int GetHighScore()
    {
        m_HighScore = PrefabsData.HighSore;
        return m_HighScore;
    }
    public int GetCurrentScore()
    {
        m_CurrentScore = PrefabsData.CurrentScore;
        return m_CurrentScore;
    }
    public void SetUpCurrentScore(int score)
    {
        m_CurrentScore += score;
        SaveCurrentScore(m_CurrentScore);
    }
    public void SetDownCurrentScore(int score)
    {
        m_CurrentScore -= score;
        SaveCurrentScore(m_CurrentScore);
    }
    public void SetUpCoin(int coin)
    {
        m_Coin += Mathf.RoundToInt(coin + (coin * m_UpMoney));
        SaveCoin(m_Coin);
    }
    public void SetDownCoin(int coin)
    {
        if (m_Coin - coin < 0) return;
        m_Coin -= coin;
        SaveCoin(m_Coin);
    }
    public int GetCoin()
    {
        m_Coin = PrefabsData.Coin;
        return m_Coin;
    }

    public void SetUpPower(int power)
    {
        m_Power += Mathf.RoundToInt(power + (power * m_UpPower));
        SavePower(m_Power);
    }
    public void SetDownPower(int power)
    {
        if (m_Power - power < 0) return;
        m_Power -= power;
        SavePower(m_Power);
    }
    public int GetPower()
    {
        m_Power = PrefabsData.Power;
        return m_Power;
    }

    public void SetIndex(int index)
    {
        m_Index = index;
        SaveIndex(index);
    }
    public int GetIndex()
    {
        m_Index = PrefabsData.CurrentIndex;
        return m_Index;
    }
}
