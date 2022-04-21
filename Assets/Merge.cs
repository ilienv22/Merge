using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    int ID;
    public GameObject MergedObject; // � ������� ������� �������� ������ ����� ������
    Transform Block1;
    Transform Block2;
    public float Distance;   //  ��� ��������� ������,
    public float MergeSpeed; // �������� ��������� ������������� ���� � �����. �������� ���� �� ���������� ������������� � �����

    bool CanMerge;
    bool MouseReleased;

    private void FixedUpdate() // ������ �������� ����������
    {
        MoveTowards();
    }

    public void MoveTowards() // �������� ��� ������������� � �������������� ������� � �� ����� ��������� � OnCollisionStay2D?
    {
        if (CanMerge)
        {
            transform.position = Vector2.MoveTowards(Block1.position, Block2.position, MergeSpeed);
            Debug.Log($"MERGE TRYIED {gameObject.name}");
            Debug.Log($"MERGE DONE {gameObject.name}");
            GameObject O = Instantiate(MergedObject, transform.position, Quaternion.identity) as GameObject;// ������� ����� ������
            Destroy(Block2.gameObject);// ���������� ��, ���
            Destroy(gameObject);       //    �����������
        }
    }

    private void OnCollisionStay2D(Collision2D collision) // ���� ���� ������ �������� �������
    {
        if (MouseReleased) // ���� ���� ���������
        {
            if (collision.gameObject.CompareTag("MergeBlock")) // ���� ������ �������� �������, ������� ����� �����������
            {
                if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == GetComponent<SpriteRenderer>().sprite)
                {
                    Block1 = transform;
                    Block2 = collision.transform;
                    CanMerge = true;                         
                }
            }
            MouseReleased = false; // ��� ������ ���������, ����� �� ����������, ���� ����� � ������� "�� ���������"
        }
    }

    void OnMouseUp()
    {
        Debug.Log($"MouseUp");
        MouseReleased = true;
    }
}
