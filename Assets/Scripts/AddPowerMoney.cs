using UnityEngine;

public class AddPowerMoney : MonoSingleton<AddPowerMoney>
{
    [SerializeField] private ListDataItems m_ListDataItem;
    public void UpPower()
    {
        if (m_ListDataItem == null) return;
        int index = GameManager.Instance.GetIndex();
        int power = m_ListDataItem.m_LisDataItems[index].m_Power;
        GameManager.Instance.SetUpPower(power);
    }
    public void DownPower(int power)
    {
        if (m_ListDataItem == null) return;
        GameManager.Instance.SetDownPower(power);
    }
    public void PowerToMoney()
    {
        int power = GameManager.Instance.GetPower();
        GameManager.Instance.SetDownPower(power);
        GameManager.Instance.SetUpCoin(power);
    }
    public int GetScalePower()
    {
        if (m_ListDataItem == null) return 0;
        int index = GameManager.Instance.GetIndex();
        return m_ListDataItem.m_LisDataItems[index].m_Power; ;
    }
}
