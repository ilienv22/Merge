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

    // ���� ������ ���������� ������� �� ������ ������ �����.
    // � ���� ������� ���������� ����, ������� �� ��������� � GridGenerator, ���� �� � �����������!
    private void OnTriggerStay2D(Collider2D collider) // ���� ���� ������� �������� �������
    {
        if (MouseUp) // ���� ���� ���������
        {
            Debug.Log($"OnTrigger");
            if (collider.gameObject.CompareTag("Grid")) // ���� ������� �������� ������ �����
            {
                Debug.Log($"PLACE {gameObject.name} ON GRID");
                Block1 = transform;
                Block2 = collider.transform;
                transform.position = Vector2.MoveTowards(Block1.position, Block2.position, speed); // ������� ������� �� ������� �����
            }
        }
    }
    void OnMouseDown() // �������� � ����� ��������� ����  - ���� ���� ������, ������������� �� �����.
    {
        Debug.Log($"MouseUp");
        MouseUp = false;
    }
    
}
