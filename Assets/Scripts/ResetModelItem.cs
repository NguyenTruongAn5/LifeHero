using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetModelItem : MonoSingleton<ResetModelItem>
{
    [SerializeField] private Transform m_objParent;
    private void Start()
    {
        LoadComponent();
    }
    private void Update()
    {
        ResetToNormalScale(this.transform);
    }
    public void ResetToNormalScale(Transform transform)
    {
        transform.localScale = new Vector3(1 / m_objParent.localScale.x,
           1 / m_objParent.localScale.y, 1 / m_objParent.localScale.z);
    }

    private void LoadComponent()
    {
        m_objParent = GameObject.FindGameObjectWithTag(ManagerTag.m_player).transform;
    }

    public void ResetSacle(Transform objParent, float m_Scale_Power)
    {
        Vector3 scaleParent = objParent.localScale;

        Vector3 newScale = new Vector3(0.4f, 0.4f, 0.4f);
        transform.localScale = newScale;
    }
    private void Reset()
    {
        m_objParent = GameObject.FindGameObjectWithTag(ManagerTag.m_player).transform;
    }
}
