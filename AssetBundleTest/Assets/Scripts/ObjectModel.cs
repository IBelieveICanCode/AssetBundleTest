using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectModel : MonoBehaviour {

    Timer timer;
    MeshRenderer mesh;
    Material mat;
	// Use this for initialization
	void Awake () {
        timer = new Timer(1, ChangeColor);
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
	}

    private void Start()
    {
        timer.Restart();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void ChangeColor()
    {
        mat.color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }
}
