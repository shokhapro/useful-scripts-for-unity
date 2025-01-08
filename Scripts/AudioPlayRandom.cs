using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayRandom : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [Space]
    [SerializeField] AudioSourcePool pool;

    private AudioSource _as;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }

    public void PlayRandom()
    {
        var r = Random.Range(0, clips.Length);

        if (pool != null)
        {
            pool.Play(clips[r]);

            return;
        }

        _as.clip = clips[r];
        _as.Play();
    }
}
