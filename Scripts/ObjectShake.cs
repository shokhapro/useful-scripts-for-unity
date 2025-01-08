using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectShake : MonoBehaviour
{
    [Serializable]
    public class ShakeOnce
    {
        public float Time = 0.5f;
        public float DeltaTime = 0.05f;
        public float Amount = 0.1f;
    }

    [SerializeField] private ShakeOnce[] shakes = new ShakeOnce[1];

    private Transform _transform;
    
    private Vector3 _startPos;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        _startPos = _transform.localPosition;
    }
    
    public void Shake(int id)
    {
        if (id < 0 || id >= shakes.Length) id = 0;
        
        var s = shakes[id];

        IEnumerator Shaking()
        {
            float t = 0f;

            while (t < s.Time)
            {
                t += s.DeltaTime;

                _transform.localPosition = _startPos + Random.insideUnitSphere * s.Amount;

                yield return new WaitForSeconds(s.DeltaTime);
            }

            _transform.localPosition = _startPos;
        }

        StartCoroutine(Shaking());
    }
    
    public void Shake()
    {
        Shake(0);
    }
}
