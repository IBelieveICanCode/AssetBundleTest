using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObject", menuName = "CreateNewFigure", order = 51)]
public class GeometryObjectData : ScriptableObject
{
    public List<ClickColorData> ClicksData;
}
