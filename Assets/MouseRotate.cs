using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    // ��� ������ ���������� ���������� � ������� ����

    private Vector2 pointScreen;
    private Vector2 offset;

    void OnMouseDown()
    {
        Debug.Log($"MouseDown");
        pointScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position); // ���� ��� ��� ������ ����
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)); // ������� ��, ��� ����� ��� ��������
    }

    void OnMouseDrag()
    {
        Debug.Log($"MouseMoving...");
        Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);// ������ ������� ������� �� ��������� ����
        Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint); 
        transform.position = curPosition;
    }
}