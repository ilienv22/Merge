using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingData : MonoBehaviour
{
    public GameObject ButtonObject;
    bool buttonSpawned;

    public GameObject BuildObject;

    public void CreateButton()
    {
        if (!buttonSpawned)
        {
            buttonSpawned = true;
            GameObject Button = Instantiate(ButtonObject, transform.position, Quaternion.identity);
            Button.GetComponent<Button>().parentBuilding = gameObject;
        }
    }

    public void Build(GameObject button)
    {
        buttonSpawned = false;
        Destroy(button);
        GameObject newMergeObject = Instantiate(BuildObject, transform.position, Quaternion.identity);
        Destroy(gameObject.transform.GetChild(0).GetComponent<Building>().CurrentResourceObject);
        Destroy(gameObject.transform.GetChild(1).GetComponent<Building>().CurrentResourceObject);

        transform.GetChild(0).GetComponent<Building>().IsFull = false;
        transform.GetChild(1).GetComponent<Building>().IsFull = false;
    }
}


