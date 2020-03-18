using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometryObjectModel : MonoBehaviour, IClickable {

    Timer timer;
    MeshRenderer mesh;
    Material mat;

    int ClickCount;
    Color CubeColor;

	void Awake () {
        timer = new Timer(1, ChangeColor);
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
	}

    private void Start()
    {
        timer.Restart();
        Init();
    }

    private void Init()
    {
        GeometryObjectData data = Resources.Load<GeometryObjectData>("Installers/GeometryObjectData");
        int itemIndex = Random.Range(0, data.ClicksData.Count);
        ClickColorData clickData = data.ClicksData[itemIndex];
        gameObject.name = clickData.ObjectType;
    }

    void ChangeColor()
    {
        mat.color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }

    public void ReactToClick()
    {
        ClickCount++;
        print(ClickCount);
    }
}
