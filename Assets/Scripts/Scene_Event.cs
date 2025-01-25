using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Scene_Event : MonoBehaviour
{
    public UnityEvent ActualAction;
    public float Delay;
    public bool Repeat;

    private void Start()
    {
        if(Delay == 0f)
            ActualAction?.Invoke();
        else
            StartCoroutine(nameof(StartDelay));
    }

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(Delay);
        
        ActualAction?.Invoke();

        if(Repeat)
            StartCoroutine(nameof(StartDelay));
    }

    public void StopAllEvents()
    {
        StopAllCoroutines();
    }
}
