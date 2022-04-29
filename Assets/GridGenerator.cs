using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] GameObject tile;
    [SerializeField] int gridHeight = 5;
    [SerializeField] int gridWight = 5;
    [SerializeField] float tileSize = 2f;
    [SerializeField] Tilemap tileMap;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Этот скрипт генерирует второй грид из прозрачных кружочков на фоне графического грида (зеленых прямоугольников). 
    // Я завела его чтобы он хранил в себе информацию, где какой объект лежит. 
    // В будущем мы будем проверять количество одинаковых элементов рядом по этому гриду.
    // Пока что он служит просто для центрирования объекта на гриде. см. PlaceObjectsOnGrid

    private void GenerateGrid()
    {
        for(int i=0; i< gridHeight; i++)
        {
            for (int x = 0; x < gridWight; x++)
            {
                GameObject newTile = Instantiate(tile, transform);
                float posX = -21.9f + (i * tileSize + x * tileSize) / 2f; 
                float posY =  12.9f + (i * tileSize - x * tileSize) / 3.4f; 
                newTile.transform.position = new Vector2(posX, posY);
                Vector3Int pos = new Vector3Int(i, x, 0);
                newTile.name = i + ", " + x;
                if (tileMap.GetTile(pos) == null)
                    newTile.GetComponent<GridData>().isAvaliable = false;
                else
                {
                    newTile.GetComponent<GridData>().isAvaliable = true;
                    Debug.Log($"{newTile.name}");
                }
            }
        }
    }

}
