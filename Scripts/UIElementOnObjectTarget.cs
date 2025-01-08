using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementOnObjectTarget : MonoBehaviour
{
    public static List<UIElementOnObjectTarget> all = new List<UIElementOnObjectTarget>();

    [SerializeField] private string key = "";

    private void Awake()
    {
        all.Add(this);
    }

    public string GetKey()
    {
        return key;
    }
}
