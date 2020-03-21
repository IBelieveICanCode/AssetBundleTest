using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClickColorData
{
    [SerializeField]
    private string objectType;
    [SerializeField]
    private int
        minClicksCount,
        maxClicksCount;
    [SerializeField]
    private Color color;

    public string ObjectType => objectType;
    public int MinClicksCount => minClicksCount;
    public int MaxClicksCount => maxClicksCount;
    public Color Color => color;
}
