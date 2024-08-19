using UnityEngine;
using UnityEngine.UI;

public class ContronlPlayer : MonoBehaviour
{
    [SerializeField] private float m_Scale_Power;
    [SerializeField] private Button m_btn_Click;
    [SerializeField] private ListDataItems m_ListDataItem;

    GameObject m_armLeft;
    GameObject m_armRight;
    GameObject m_player;
    Animator m_animation;

    float m_ClickTime;
    float m_Timer;
    private void Start()
    {
        LoadComponent();

        m_ClickTime = 2f - (GameManager.Instance.GetUpTime() * 2f);

        m_Scale_Power = AddPowerMoney.Instance.GetScalePower();

        if (m_btn_Click == null)
        {
            m_btn_Click = GameObject.Find("btn_Click").GetComponent<Button>();
        }
        if(m_animation== null)
        {
            m_animation = gameObject.GetComponentInParent<Animator>();
        }
        if (m_btn_Click == null) return;

        m_Timer = m_ClickTime;

        m_btn_Click.onClick.RemoveAllListeners();
        m_btn_Click.onClick.AddListener(OnClickUpPower);
    }
    private void FixedUpdate()
    {
        AutoClick();
    }
    private void AutoClick()
    {
        m_Timer -= Time.fixedDeltaTime;
        if(m_Timer <= 0)
        {
            OnClickUpPower();
            m_Timer = m_ClickTime;
        }
    }
    public void OnClickUpPower()
    {
        if (m_armLeft == null || m_armRight == null || m_animation == null
            || m_player == null || m_ListDataItem == null) return;

        CountDown.Instance.StartCountDown();


        int index = GameManager.Instance.GetIndex();
        int power = m_ListDataItem.m_LisDataItems[index].m_Power;

        CalculatorScore.Instance.UpdateScore((int)m_player.transform.localScale.x);

        UpdateUI.Instance.CreateAddPower(power, m_player.transform.localScale);

        m_Scale_Power = AddPowerMoney.Instance.GetScalePower();
        ResetModelItem.Instance.ResetSacle(m_player.transform, m_Scale_Power);

        m_animation.SetTrigger(ManagerAnimations.m_Curl_Animi);

        AddPowerMoney.Instance.UpPower();

        GameObject parentScale = transform.parent.gameObject;
        if (CheckScaleFit())
        {
            ScaledObj(parentScale);
        }
        else
        {
            ScaledObj(m_armLeft);
            ScaledObj(m_armRight);
        }
    }
    private bool CheckScaleFit()
    {
        bool result = false;
        Vector3 armLeftScale = m_armLeft.transform.localScale;
        Vector3 armRightScale = m_armRight.transform.localScale;
        if (armLeftScale.x >= 1 && armLeftScale.z >= 1
            && armRightScale.x >= 1 && armRightScale.z >= 1)
        {
            Vector3 resetScale = new Vector3(1f, 1f, 1f);

            m_armLeft.transform.localScale = resetScale;
            m_armRight.transform.localScale = resetScale;
            result = true;
        }
        return result;
    }
    private void ScaledObj(GameObject obj)
    {
        if (obj == null) return;
        m_Scale_Power = AddPowerMoney.Instance.GetScalePower();
        float scaleX = CalculatorScaleHelper.CalculatorScale(obj.transform.localScale.x, m_Scale_Power);
        float scaleY;
        if (CheckScaleFit())
        {
            scaleY = CalculatorScaleHelper.CalculatorScale(obj.transform.localScale.y, m_Scale_Power);
        }
        else
        {
            scaleY = 1f;
        }
        float scaleZ = CalculatorScaleHelper.CalculatorScale(obj.transform.localScale.z, m_Scale_Power);
        obj.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    }
    
    private void LoadComponent()
    {
        LoadObjBody();
    }

    private void LoadObjBody()
    {
        m_armLeft = GameObject.FindGameObjectWithTag(ManagerTag.m_arm_Left);
        m_armRight = GameObject.FindGameObjectWithTag(ManagerTag.m_arm_Right);
        m_player = GameObject.FindGameObjectWithTag(ManagerTag.m_player);
    }
}
