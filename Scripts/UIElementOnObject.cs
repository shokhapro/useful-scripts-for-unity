using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UIElementOnObject : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private string findTargetByKey = "";
    [Space]
    [SerializeField] private Vector2 offset = Vector2.zero;
    [Space]
    [SerializeField] private bool keepOnScreen = false;
    [SerializeField] private float keepSpacing = 10f;
    [SerializeField] private Vector2 keepRectSize = new Vector2(50f, 50f);
    [SerializeField] private string getGlobalVarKeepRectSize = "";

    private RectTransform _rt;
    private Canvas _canvas;
    private Camera _c;
    private RectTransform _parentRect;

    private void Awake()
    {
        _rt = GetComponent<RectTransform>();

        _canvas = GetComponentInParent<Canvas>();

        _c = Camera.main;

        _parentRect = _rt.parent.GetComponent<RectTransform>();
    }

    private void Start()
    {
        if (findTargetByKey != "")
            FindTargetByKey(findTargetByKey);
    }

    private void LateUpdate()
    {
        RectSizeUpdate();

        PositionUpdate();
    }

    private void PositionUpdate()
    {
        var vpos = _c.WorldToScreenPoint(target.position);

        var cpos = vpos / _canvas.scaleFactor;
        
        cpos.x += offset.x;
        cpos.y += offset.y;

        if (keepOnScreen)
        {
            var canvasSize = new Vector2(Screen.width, Screen.height) / _canvas.scaleFactor;

            cpos.x = Mathf.Clamp(cpos.x, keepRectSize.x + keepSpacing, canvasSize.x - keepRectSize.x - keepSpacing);
            cpos.y = Mathf.Clamp(cpos.y, keepRectSize.y + keepSpacing, canvasSize.y - keepRectSize.y - keepSpacing);
        }

        _rt.anchoredPosition = new Vector2(cpos.x, cpos.y);
    }

    private void RectSizeUpdate()
    {
        if (getGlobalVarKeepRectSize == "") return;

        var gv = GlobalVar.Get<Vector2>(getGlobalVarKeepRectSize);

        keepRectSize = gv * 0.5f;
    }

    public void SetTarget(Transform targ)
    {
        target = targ;
    }

    private void FindTargetByKey(string key)
    {
        foreach (var targ in UIElementOnObjectTarget.all)
            if (targ.GetKey() == key)
            {
                target = targ.transform;
                break;
            }
    }
}
