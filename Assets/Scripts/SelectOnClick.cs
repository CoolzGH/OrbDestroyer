using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SelectOnClick : MonoBehaviour
{
    Ray ray;
    RaycastHit hitData;
    GameObject selectedObject;

    public static Action<GameObject> OnGameObjectHit;

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitData, 100) && Input.GetMouseButtonDown(0))
        {
            selectedObject = hitData.transform.gameObject;
            SendOrbType();
        }
    }

    void SendOrbType() 
    {
        //Debug.Log(selectedObject.name);
        OnGameObjectHit(selectedObject);
    }
}
