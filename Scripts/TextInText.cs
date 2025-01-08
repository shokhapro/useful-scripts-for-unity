using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class TextInText : MonoBehaviour
{
    [SerializeField] private string startText = "";
    [SerializeField] private string endText = "";
    
    private TextMeshPro _t;

    public void Set(string text)
    {
        if (!_t) _t = GetComponent<TextMeshPro>();
        
        _t.text = startText + text + endText;
    }
}
