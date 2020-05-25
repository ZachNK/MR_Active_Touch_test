using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialColorBlock : MonoBehaviour
{

    public Color color;

    void Start()
    {
        MaterialPropertyBlock propBlock = new MaterialPropertyBlock();
        Renderer renderer = GetComponent<Renderer>();
        renderer.GetPropertyBlock(propBlock);
        propBlock.SetColor("_Color", color);
        renderer.SetPropertyBlock(propBlock);
    }
}
