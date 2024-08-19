using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorScaleHelper : MonoSingleton<CalculatorScaleHelper>
{
    public static float CalculatorScale(float scaleCurrent, float m_Scale_Power)
    {
        float reuslt;
        if (scaleCurrent < 10)
        {
            reuslt = scaleCurrent + m_Scale_Power * scaleCurrent * 0.002f;
        }
        else if (scaleCurrent >= 10 && scaleCurrent < 50)
        {
            reuslt = scaleCurrent + m_Scale_Power * scaleCurrent * 0.00002f;
        }
        else if (scaleCurrent >= 50 && scaleCurrent < 100)
        {
            reuslt = scaleCurrent + m_Scale_Power * scaleCurrent * 0.0000002f;
        }
        else if (scaleCurrent >= 100 && scaleCurrent < 150)
        {
            reuslt = scaleCurrent + m_Scale_Power * scaleCurrent * 0.000000002f;
        }
        else if (scaleCurrent >= 150 && scaleCurrent < 200)
        {
            reuslt = scaleCurrent + m_Scale_Power * scaleCurrent * 0.00000000002f;
        }
        else
        {
            reuslt = scaleCurrent + m_Scale_Power * scaleCurrent * 0.000000000000001f;
        }
        return reuslt;
    }
    public static float ScaleNormal(float scaleCurrent, float m_Scale_Power)
    {
        float reuslt;
        if (scaleCurrent < 10)
        {
            reuslt = scaleCurrent/(scaleCurrent + m_Scale_Power * scaleCurrent * 0.002f);
        }
        else if (scaleCurrent >= 10 && scaleCurrent < 50)
        {
            reuslt = scaleCurrent/(scaleCurrent + m_Scale_Power * scaleCurrent * 0.00002f);
        }
        else if (scaleCurrent >= 50 && scaleCurrent < 100)
        {
            reuslt = scaleCurrent/(scaleCurrent + m_Scale_Power * scaleCurrent * 0.0000002f);
        }
        else if (scaleCurrent >= 100 && scaleCurrent < 150)
        {
            reuslt = scaleCurrent/(scaleCurrent + m_Scale_Power * scaleCurrent * 0.000000002f);
        }
        else if (scaleCurrent >= 150 && scaleCurrent < 200)
        {
            reuslt = scaleCurrent / (scaleCurrent + m_Scale_Power * scaleCurrent * 0.00000000002f);
        }
        else
        {
            reuslt = scaleCurrent / (scaleCurrent + m_Scale_Power * scaleCurrent * 0.000000000000001f);
        }
        return reuslt;
    }
}
