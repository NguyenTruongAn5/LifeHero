using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoSingleton<UpdateUI>
{
    [SerializeField] private Text m_txt_Power;
    [SerializeField] private Text m_txt_Money;
    [SerializeField] private GameObject m_AddPower;

    [SerializeField] private Button m_btnUpGrade;

    [SerializeField] private GameObject m_pannelUpgrade;


    private void Start()
    {
        LoadComponent();
    }
    private void Update()
    {
        UpdateTxtPower();
        UpdateTxtMoney();
    }

    public void UpdateTxtPower()
    {
        int power = GameManager.Instance.GetPower();
        m_txt_Power.text = power.ToString();
    }
    public void UpdateTxtMoney()
    {
        int money = GameManager.Instance.GetCoin();
        m_txt_Money.text = money.ToString();
    }
    public void CreateAddPower(int power, Vector3 scale)
    {
        if (m_AddPower == null) return;
        float random = Random.Range(1f, 6f);
        GameObject obj = Instantiate(m_AddPower);

        RectTransform reTran = obj.GetComponentInChildren<RectTransform>();
        reTran.localPosition = new Vector3(random, random, random);

        reTran.localScale = scale;
        TextMesh txtPower = obj.GetComponentInChildren<TextMesh>();
        txtPower.text = "+" + power.ToString();
    }

    private void LoadComponent()
    {
        m_txt_Power = GameObject.FindGameObjectWithTag(ManagerTag.m_txt_Power)
            .GetComponent<Text>();
        m_txt_Money = GameObject.FindGameObjectWithTag(ManagerTag.m_txt_Money)
           .GetComponent<Text>();
        m_btnUpGrade = GameObject.Find("btn_Battle").GetComponent<Button>();

        m_btnUpGrade.onClick.RemoveAllListeners();
        m_btnUpGrade.onClick.AddListener(OnClickShowUpgrade);

        
    }

    private void OnClickShowUpgrade()
    {
        if (m_pannelUpgrade == null) return;
        m_pannelUpgrade.gameObject.SetActive(true);
    }


    private void Reset()
    {
        LoadComponent();
    }
}
