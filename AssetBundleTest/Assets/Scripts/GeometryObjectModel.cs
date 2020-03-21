using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometryObjectModel : MonoBehaviour, IClickable {

    [SerializeField]
    Material mat;

    [HideInInspector]
    public ClickColorData ClickData;
    [SerializeField]
    int ClickCount;
    Color CubeColor;

    public void ReactToClick()
    {
        ClickCount++;
        if (ClickCount > ClickData.MinClicksCount && ClickCount < ClickData.MaxClicksCount)
        {
            ChangeColor(ClickData.Color);
        }
    }
    public void ChangeColor()
    {        
        CubeColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        mat.color = CubeColor;
    }

    void ChangeColor(Color color)
    {
        CubeColor = color;
        mat.color = CubeColor;
    }
}
