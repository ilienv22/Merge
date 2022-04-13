using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectsOnGrid : MonoBehaviour
{

    private float speed = 1.0f;
    bool MouseUp = true;
    Transform Block1;
    Transform Block2;

    void OnMouseUp()
    {
        Debug.Log($"MouseUp");
        MouseUp = true;
    }

    // Этот скрипт центрирует элемент по центру клетки грида.
    // В этом скрипте фигурирует грид, который мы сгенерили в GridGenerator, речь не о графическом!
    private void OnTriggerStay2D(Collider2D collider) // Пока один элемент касается другого
    {
        if (MouseUp) // если мышь отпустили
        {
            Debug.Log($"OnTrigger");
            if (collider.gameObject.CompareTag("Grid")) // если элемент касается именно грида
            {
                Debug.Log($"PLACE {gameObject.name} ON GRID");
                Block1 = transform;
                Block2 = collider.transform;
                transform.position = Vector2.MoveTowards(Block1.position, Block2.position, speed); // Элемент двигаем на позицию грида
            }
        }
    }
    void OnMouseDown() // логируем в каком состоянии мышь  - если мышь нажата, центрирование не нужно.
    {
        Debug.Log($"MouseUp");
        MouseUp = false;
    }
    
}
