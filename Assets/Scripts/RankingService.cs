using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class RankingService : MonoBehaviour
{
    private static GoogleSheetsRanking rankingInstance;
    public bool CheckTop5;
    public UnityEvent OnRankingDone;
    [SerializeField] private TextMeshProUGUI top5String;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI tusPuntos;

    public void Start()
    {
        rankingInstance = GameObject.FindObjectOfType<GoogleSheetsRanking>();
        
        if (rankingInstance == null)
        {
            Debug.LogError("GoogleSheetsRanking instance not found in the scene.");
        }

        rankingInstance.OnRankingUpdated += OnRankingUpdated;
    }

    private void OnRankingUpdated()
    {
        if (CheckTop5)
        {
            var top5List = rankingInstance.GetTop5String();
            top5String.text = string.Join("\n", top5List);
        }
        OnRankingDone.Invoke();
    }

    public void GetRanking()
    {
        rankingInstance.ObtenerRanking();
    }

    public void SendScore()
    {
        rankingInstance.EnviarPuntuacion(playerName.text, GoogleSheetsRanking.Instance.currentScore);
    }

    public void Reset()
    {
        rankingInstance.Reset();
    }

    public void GetTop5()
    {
        rankingInstance.GetTop5();
    }
    
    public void GetTusPuntos()
    {
        tusPuntos.text = "Tus puntos: " + GoogleSheetsRanking.Instance.currentScore;
    }
}