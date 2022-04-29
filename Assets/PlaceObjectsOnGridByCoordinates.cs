using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectsOnGridByCoordinates : MonoBehaviour
{
    public float speed = 1.0f;
    public bool MouseUp = true;
    public float gridSize = 2f;

    private Grid graphicGrid;

    private void Start()
    {
        graphicGrid = Grid.FindObjectOfType<Grid>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collider) // ѕока один элемент касаетс€ другого
    {
        if (collider.gameObject.CompareTag("Grid")) // если элемент касаетс€ именно грида
        {
            if (gameObject.GetComponent<ObjectData>().currentPosition == null) // если еще не назначена €чейка грида, назначаем
                gameObject.GetComponent<ObjectData>().currentPosition = collider.gameObject.gameObject;

            if (!gameObject.GetComponent<ObjectData>().IsOnPlace && collider.gameObject == gameObject.GetComponent<ObjectData>().currentPosition)
            {
                gameObject.GetComponent<ObjectData>().IsOnPlace = true;
            }
            if (gameObject.GetComponent<ObjectData>().IsOnPlace && collider.gameObject.GetComponent<GridData>().isAvaliable && collider.gameObject.GetComponent<GridData>().isEmpty)
            {
                if (gameObject.GetComponent<ObjectData>().currentPosition != null)
                    gameObject.GetComponent<ObjectData>().currentPosition.GetComponent<GridData>().isEmpty = true;
                PlaceOnGrid(gameObject);
                if (MouseUp)
                {
                    gameObject.GetComponent<ObjectData>().currentPosition = collider.gameObject;
                    transform.position = Vector2.MoveTowards(gameObject.transform.position, collider.transform.position, speed);
                    collider.gameObject.GetComponent<GridData>().isEmpty = false;
                    gameObject.GetComponent<ObjectData>().IsOnPlace = true;
                }
            }
            else
            {
                ReturnOnPrevPlace(gameObject);
            }
        }
    }

    public void PlaceOnGrid(GameObject Block)
    {
        if (MouseUp)
        {
            Vector3Int cp = graphicGrid.LocalToCell(transform.position);
            transform.position = Vector3.MoveTowards(transform.position, graphicGrid.GetCellCenterLocal(cp), speed);
            Block.GetComponent<ObjectData>().IsOnPlace = true;
        }
    }

    public void ReturnOnPrevPlace(GameObject Block1)
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

    public void OnMouseDown() // логируем в каком состо€нии мышь  - если мышь нажата, центрирование не нужно.
    {
        MouseUp = false;
    }

    void OnMouseUp()
    {
        MouseUp = true;
    }
}
