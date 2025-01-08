using UnityEngine;
using UnityEngine.UI;

public class ContentSizeGrid : MonoBehaviour
{
    [SerializeField] private float spacing = 5f;
    [Space]

    private RectTransform _rt;

    private void Awake()
    {
        _rt = GetComponent<RectTransform>();
    }

    private void Start()
    {
        Rebuild();
    }

    public void Rebuild()
    {
        var width = 0f;

        width += spacing;
        width += spacing;

        for (int i = 0; i < _rt.childCount; i++)
        {
            if (!_rt.GetChild(i).gameObject.activeSelf) continue;

            var rect = _rt.GetChild(i).GetComponent<RectTransform>();

            var sizex = rect.rect.width;

            var fitter = rect.GetComponent<ContentSizeFitter>();
            if (fitter != null) sizex = LayoutUtility.GetPreferredWidth(rect);

            rect.anchoredPosition = new Vector2 (width + sizex * 0.5f, 0f);

            width += sizex;

            width += spacing;
        }

        width += spacing;

        _rt.sizeDelta = new Vector2 (width, _rt.sizeDelta.y);

        SetGlobalVar();
    }

    private void SetGlobalVar()
    {
        //_rt.sizeDelta
    }
}
