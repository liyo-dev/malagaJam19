using TMPro;
using UnityEngine;

public class ScoreUIManager : MonoBehaviour
{
    public static ScoreUIManager Instance { get; private set; }
    
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        UpdateScoreTextReference();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Instance.UpdateScoreTextReference();
            Destroy(gameObject);
        }
    }

    public void UpdateUI()
    {
        scoreText.text = "Score: " + GoogleSheetsRanking.Instance.currentScore;
    }

    public void UpdateScoreTextReference()
    {
        scoreText = GameObject.FindGameObjectWithTag("TextScore").GetComponent<TextMeshProUGUI>();
        GoogleSheetsRanking.Instance.currentScore = 0;
        UpdateUI();
    }
}
