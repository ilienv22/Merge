using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    // это просто управление элементами с помощью мыши

    private Vector2 pointScreen;
    private Vector2 offset;

    void OnMouseDown()
    {
        pointScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position); // ищем над чем нажали мышь
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)); // двигаем то, что нашли под курсором
    }

    void OnMouseDrag()
    {
        Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);// меняем позицию объекта за движением мыши
        Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint); 
        transform.position = curPosition;
    }
}
