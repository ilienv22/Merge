using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectsOnGrid : MonoBehaviour
{
    public float speed = 1.0f;
    public bool MouseUp = true;
    public Transform Block1;
    public Transform Block2;

    void OnMouseUp()
    {
        MouseUp = true;
    }

    // Этот скрипт центрирует элемент по центру клетки грида.
    // В этом скрипте фигурирует грид, который мы сгенерили в GridGenerator, речь не о графическом!
    private void OnTriggerStay2D(Collider2D collider) // Пока один элемент касается другого
    {    
        if (collider.gameObject.CompareTag("Grid")) // если элемент касается именно грида
        {
            if (gameObject.GetComponent<ObjectData>().currentPosition == null) // если еще не назначена ячейка грида, назначаем
                gameObject.GetComponent<ObjectData>().currentPosition = collider.gameObject.gameObject;

            if (!gameObject.GetComponent<ObjectData>().IsOnPlace && collider.gameObject == gameObject.GetComponent<ObjectData>().currentPosition)
                {
                    gameObject.GetComponent<ObjectData>().IsOnPlace = true;
                }
            if (gameObject.GetComponent<ObjectData>().IsOnPlace && collider.gameObject.GetComponent<GridData>().isAvaliable && collider.gameObject.GetComponent<GridData>().isEmpty)
                {
                    if (gameObject.GetComponent<ObjectData>().currentPosition != null)
                        gameObject.GetComponent<ObjectData>().currentPosition.GetComponent<GridData>().isEmpty = true;
                    PlaceOnGrid(gameObject, collider.gameObject);
                }
            else
                {
                    ReturnOnPrevPlace(gameObject, collider.gameObject);
                }
        }
    }

    public void PlaceOnGrid(GameObject Block1, GameObject Block2)
    {
        if (MouseUp)
        {
            Block1.GetComponent<ObjectData>().currentPosition = Block2.gameObject;
            transform.position = Vector2.MoveTowards(Block1.transform.position, Block2.transform.position, speed);
            Block2.gameObject.GetComponent<GridData>().isEmpty = false;
            Block1.GetComponent<ObjectData>().IsOnPlace = true;
        }
    }

    public void ReturnOnPrevPlace(GameObject Block1, GameObject Block2)
    {
        if (MouseUp)
        {
            if (Block1.GetComponent<ObjectData>().currentPosition != null)
            {
                Block1.GetComponent<ObjectData>().IsOnPlace = false;
                Block1.transform.position = Vector2.MoveTowards(Block1.transform.position, Block1.GetComponent<ObjectData>().currentPosition.transform.position, speed);
            }
        }
    }

    public void OnMouseDown() // логируем в каком состоянии мышь  - если мышь нажата, центрирование не нужно.
    {
        MouseUp = false;
    }
    
}
