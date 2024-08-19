using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorMoneyPower : MonoSingleton<CalculatorMoneyPower>
{
    public int UpPower(int power)
    {
        int result = GameManager.Instance.GetPower() + power;
        return result;
    }
    public int DownPower(int power)
    {
        int result = GameManager.Instance.GetPower() - power;
        return result;
    }
    public int PowerToMoney()
    {
        int result = GameManager.Instance.GetCoin() + GameManager.Instance.GetPower();
        return result;
    }
}
