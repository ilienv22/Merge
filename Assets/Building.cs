using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public bool IsFull = false;
    public GameObject ResourceObject;
    public GameObject BuildObject;

    public GameObject CurrentResourceObject;

    float timeLeft = 30.0f;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!IsFull)
        {
            if (collision.gameObject.CompareTag("MergeBlock"))
            {
                if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == ResourceObject.GetComponent<SpriteRenderer>().sprite)
                {
                    IsFull = true;
                    CurrentResourceObject = collision.gameObject;
                    collision.gameObject.GetComponent<ObjectData>().IsBlocked = true;
                    gameObject.transform.root.GetComponent<BuildingData>().CreateButton();
                }
            }
        }
    }
}
