using UnityEngine;
using DG.Tweening;

public class DOTPopEffect : MonoBehaviour
{
    public float popScale = 1.2f;
    public float popDuration = 0.2f;

    private RectTransform _buttonRectTransform;

    private void Start()
    {
        PopEffect();
    }

    public void PopEffect()
    {
        _buttonRectTransform = GetComponent<RectTransform>();
        
        Vector3 initialScale = _buttonRectTransform.localScale;
        
        Vector3 targetScale = initialScale * popScale;
        
        _buttonRectTransform.localScale = initialScale;
        
        Sequence popSequence = DOTween.Sequence();
        popSequence.Append(_buttonRectTransform.DOScale(targetScale, popDuration));
        popSequence.Append(_buttonRectTransform.DOScale(initialScale, popDuration / 2).SetEase(Ease.OutElastic)); 

        popSequence.Play();
    }
}