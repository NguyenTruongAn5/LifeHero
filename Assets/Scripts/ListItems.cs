using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListItem", menuName = "TA/Data/ListItems")]
public class ListItems : ScriptableObject
{
    public List<GameObject> m_listItem;
}