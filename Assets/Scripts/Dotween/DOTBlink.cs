using DG.Tweening;
using UnityEngine;

public class DOTBlink : MonoBehaviour
{
    private float blinkDuration = 2f;
    private int blinkCount = 2;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
        
        transform.DOShakeScale(blinkDuration, 0.5f, blinkCount, 90f, false)
            .OnComplete(() => {
                transform.localScale = originalScale;
            })
            .SetEase(Ease.Linear).SetLoops(-1);
    }
}
