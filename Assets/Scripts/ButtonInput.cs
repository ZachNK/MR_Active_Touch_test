using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonInput : MonoBehaviour, IInputClickHandler, IFocusable
{
    public UnityEvent onClick;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    public Color highlightedcolor;
    public Color disabledcolor;

    private void Awake()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void OnFocusEnter()
    {
        _renderer.GetPropertyBlock(_propBlock);
        _propBlock.SetColor("_Color", highlightedcolor);
        _renderer.SetPropertyBlock(_propBlock);
    }

    public void OnFocusExit()
    {
        _renderer.GetPropertyBlock(_propBlock);
        _propBlock.SetColor("_Color", disabledcolor);
        _renderer.SetPropertyBlock(_propBlock);
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        //GameObject.Find("LogText").GetComponent<TextMesh>().text += "clicked " + gameObject.name + "\n";
        OnFocusExit();
        if (onClick != null)
            onClick.Invoke();
    }
}