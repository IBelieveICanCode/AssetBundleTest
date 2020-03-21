using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometryObjectModel : MonoBehaviour, IClickable {

    Timer timer;
    MeshRenderer mesh;
    Material mat;

    [HideInInspector]
    public ClickColorData ClickData;
    [HideInInspector]
    public GameData GameData;
    int ClickCount;
    Color CubeColor;

    void Awake () {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }


    public void Init()
    {
        timer = new Timer(GameData.ObservableTime, ChangeColor);
        timer.Restart();
    }
    public void ReactToClick()
    {
        ClickCount++;
        if (ClickCount > ClickData.MinClicksCount && ClickCount < ClickData.MaxClicksCount)
        {
            ChangeColor(ClickData.Color);
        }
    }
    void Update()
    {
        mat.color = CubeColor;
    }

    void ChangeColor()
    {
        CubeColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }

    void ChangeColor(Color color)
    {
        CubeColor = color;
    }
}
