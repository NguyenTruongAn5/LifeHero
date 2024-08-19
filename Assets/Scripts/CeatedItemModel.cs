using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class CeatedItemModel : MonoSingleton<CeatedItemModel>
{
    [SerializeField] private ListItems m_objItem;
    [SerializeField] private Transform m_parentObj;
    [SerializeField] private List<GameObject> m_poolItem;

    private void Start()
    {
        LoadCompent();
        CreateItem(GameManager.Instance.GetIndex());
    }

    public void CreateItem(int index)
    {
        for(int i = 0; i < m_poolItem.Count; i++)
        {
            if(i == index)
            {
                m_poolItem[i].gameObject.SetActive(true);
            }
            else
            {
                m_poolItem[i].gameObject.SetActive(false);
            }
        }
    }
    private void Reset()
    {
        LoadCompent();
    }
    private void LoadCompent()
    {
        m_poolItem = new List<GameObject>();
        m_parentObj = GameObject.Find("ModelItem").transform;
        this.LoadAllItem();
    }

    private void LoadAllItem()
    {
        foreach(var item in m_objItem.m_listItem)
        {
            GameObject obj = Instantiate(item);
            obj.transform.SetParent(m_parentObj);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;
            obj.SetActive(false);
            m_poolItem.Add(obj);
        }
    }
}
