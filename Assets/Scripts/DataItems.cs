using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data Item", menuName ="TA/Data/DataItems")]
public class DataItems : ScriptableObject
{
    public string m_NameItem;
    public int m_Power;
    public int m_Dola;
    public bool is_Bought;
}
