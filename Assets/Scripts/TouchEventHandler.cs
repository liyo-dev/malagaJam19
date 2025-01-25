using UnityEngine;
using UnityEngine.Events;

public class TouchEventHandler : MonoBehaviour
{
    public UnityEvent OnTouchEvent;
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0)) 
        {
            OnTouchEvent?.Invoke();
        }
    }
}
