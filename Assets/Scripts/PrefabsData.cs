using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PrefabsData
{
    public static int PriceTime
    {
        get => PlayerPrefs.GetInt(PrefsKey.PriceTime.ToString(), 1500);
        set => PlayerPrefs.SetInt(PrefsKey.PriceTime.ToString(), value);
    }
    public static int PricePower
    {
        get => PlayerPrefs.GetInt(PrefsKey.PricePower.ToString(), 1500);
        set => PlayerPrefs.SetInt(PrefsKey.PricePower.ToString(), value);
    }
    public static int PriceMoney
    {
        get => PlayerPrefs.GetInt(PrefsKey.PriceMoney.ToString(), 1500);
        set => PlayerPrefs.SetInt(PrefsKey.PriceMoney.ToString(), value);
    }
    public static int CurrentIndex
    {
        get => PlayerPrefs.GetInt(PrefsKey.CurrentIndex.ToString(), 0);
        set => PlayerPrefs.SetInt(PrefsKey.CurrentIndex.ToString(), value);
    }
    public static int Coin
    {
        get => PlayerPrefs.GetInt(PrefsKey.Coin.ToString(), 0);
        set => PlayerPrefs.SetInt(PrefsKey.Coin.ToString(), value);
    }
    public static int Power
    {
        get => PlayerPrefs.GetInt(PrefsKey.Power.ToString(), 0);
        set => PlayerPrefs.SetInt(PrefsKey.Power.ToString(), value);
    }
    public static int HighSore
    {
        get => PlayerPrefs.GetInt(PrefsKey.HighSore.ToString(), 0);
        set
        {
            int highScore = PlayerPrefs.GetInt(PrefsKey.HighSore.ToString(), 0);
            if (highScore >= value) return;
            PlayerPrefs.SetInt(PrefsKey.HighSore.ToString(), value);
        }
    }
    public static float UpTime
    {
        get => PlayerPrefs.GetFloat(PrefsKey.UpTime.ToString(), 0);
        set
        {
            float time = PlayerPrefs.GetFloat(PrefsKey.UpTime.ToString(), 0);
            if (time >= 0.51) return;
            PlayerPrefs.SetFloat(PrefsKey.UpTime.ToString(), value);
        }
    }
    public static float UpPower
    {
        get => PlayerPrefs.GetFloat(PrefsKey.UpPower.ToString(), 0);
        set
        {
            float power = PlayerPrefs.GetFloat(PrefsKey.UpPower.ToString(), 0);
            if (power >= 0.51) return;
            PlayerPrefs.SetFloat(PrefsKey.UpPower.ToString(), value);
        }
    }
    public static float UpMoney
    {
        get => PlayerPrefs.GetFloat(PrefsKey.UpMoney.ToString(), 0);
        set
        {
            float money = PlayerPrefs.GetFloat(PrefsKey.UpMoney.ToString(), 0);
            if (money >= 0.51) return;
            PlayerPrefs.SetFloat(PrefsKey.UpMoney.ToString(), value);
        }
    }
    public static int CurrentScore
    {
        get => PlayerPrefs.GetInt(PrefsKey.CurrentScore.ToString(), 0);
        set => PlayerPrefs.SetInt(PrefsKey.CurrentScore.ToString(), value);
    }
}
