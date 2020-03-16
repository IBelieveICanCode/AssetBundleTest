using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckFigures();
        }
	}

    void CheckFigures()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            print("kok");
        }
    }
}
