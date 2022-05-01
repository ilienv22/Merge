using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool SetTimer = false;
    float timeLeft = 5.0f;
    public GameObject parentBuilding;

    void Update()
    {
        if (SetTimer)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                SetTimer = false;
                parentBuilding.GetComponent<BuildingData>().Build(gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        SetTimer = true;
    }

}
