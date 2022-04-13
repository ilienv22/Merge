using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] GameObject tile;
    [SerializeField] int gridHeight = 10;
    [SerializeField] int gridWight = 10;
    [SerializeField] float tileSize = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // ���� ������ ���������� ������ ���� �� ���������� ��������� �� ���� ������������ ����� (������� ���������������). 
    // � ������ ��� ����� �� ������ � ���� ����������, ��� ����� ������ �����. 
    // � ������� �� ����� ��������� ���������� ���������� ��������� ����� �� ����� �����.
    // ���� ��� �� ������ ������ ��� ������������� ������� �� �����. ��. PlaceObjectsOnGrid

    private void GenerateGrid()
    {
        for(int i=0; i< gridHeight; i++)
        {
            for (int x = 0; x < gridWight; x++)
            {
                GameObject newTile = Instantiate(tile, transform);
                float posX = 2.34f + (i * tileSize + x * tileSize) / 2f; // 2.34f, -0.18f - ����������� ���� ��������, ����� ���� ����
                float posY = -0.18f + (i * tileSize - x * tileSize) / 4f; //                � ����������� ��������� � ������������

                newTile.transform.position = new Vector2(posX, posY);
                newTile.name = i + ", " + x;
            }
        }
    }

}
