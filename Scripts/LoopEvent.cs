using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoopEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent call;
    [Space]
    [SerializeField] private float interval = 1f;
    [SerializeField] [Range(0f, 1f)] private float randomize = .2f;
    [SerializeField] private bool afterInterval = false;

    private Coroutine _coroutine;

    IEnumerator Looping()
    {
        while (true)
        {
            if (!afterInterval) call.Invoke();

            var r = Random.Range(-interval * randomize, interval * randomize);

            yield return new WaitForSeconds(interval + r);

            if (afterInterval) call.Invoke();
        }
    }

    public void SetInterval(float value)
    {
        interval = value;
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Looping());
    }

    private void OnDisable()
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
    }
}
