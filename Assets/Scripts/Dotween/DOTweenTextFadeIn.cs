using UnityEngine;
using TMPro;
using DG.Tweening;

public class DOTweenTextFadeIn : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float fadeInDuration = 1.0f;
    public float delay = 0.0f;

    void Start()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("El componente TextMeshProUGUI no está asignado en el Inspector.");
            return;
        }
        
        FadeIn();
    }

    void FadeIn()
    {
        Color textColor = textMeshPro.color;
        textColor.a = 0f;
        textMeshPro.color = textColor;

        Sequence fadeInSequence = DOTween.Sequence();
        fadeInSequence.AppendInterval(delay); 
        fadeInSequence.Append(textMeshPro.DOFade(1f, fadeInDuration)); 

        fadeInSequence.Play();
    }
}