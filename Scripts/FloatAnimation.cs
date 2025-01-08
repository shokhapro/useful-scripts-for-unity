using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class FloatAnimation : MonoBehaviour
{
    [SerializeField] private float value = 1f;
    [Space]
    [SerializeField] private AnimationCurve[] curves;
    [SerializeField] private float time = 1f;

    private Coroutine _coroutine;

    public void Play(int index)
    {
        if (index >= curves.Length) return;

        if (_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(anim());

        IEnumerator anim()
        {
            float t = 0f;
            while (t < time)
            {
                t += Time.deltaTime;

                value = curves[index].Evaluate(t / time);

                yield return null;
            }
        }
    }

    public void Play()
    {
        Play(0);
    }

    public float GetValue()
    {
        return value;
    }
}
