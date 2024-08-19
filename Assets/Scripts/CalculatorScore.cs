using UnityEngine;

public class CalculatorScore : MonoSingleton<CalculatorScore>
{
    [SerializeField] private TextMesh txt_CurrentScore;
    [SerializeField] private TextMesh txt_HighScore;
    private void Reset()
    {
        LoadComponent();
    }
    private void Start()
    {
        LoadComponent();
    }

    public void UpdateScore(int score)
    {
        GameManager.Instance.SetUpCurrentScore(score);
        UpdateUIScore();
    }

    private void UpdateUIScore()
    {
        if (txt_CurrentScore == null || txt_HighScore == null) return;
        int score = GameManager.Instance.GetCurrentScore();
        int highScore = GameManager.Instance.GetHighScore();
        txt_CurrentScore.text = score.ToString();
        if(score > highScore)
        {
            txt_HighScore.text = score.ToString();
            GameManager.Instance.SetHighScore(score);
        }
    }

    private void LoadComponent()
    {
        txt_CurrentScore = GameObject.FindGameObjectWithTag(ManagerTag.m_Current_Score).
            GetComponent<TextMesh>();
        txt_HighScore = GameObject.FindGameObjectWithTag(ManagerTag.m_High_Score).
            GetComponent<TextMesh>();

        if(txt_HighScore == null || txt_CurrentScore== null) return;    
        txt_CurrentScore.text = GameManager.Instance.GetCurrentScore().ToString() + " m";
        txt_HighScore.text = "High score "+GameManager.Instance.GetHighScore().ToString() + " m";
    }
}
