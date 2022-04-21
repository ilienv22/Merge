using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] GameObject tile;
    [SerializeField] int gridHeight = 4;
    [SerializeField] int gridWight = 4;
    [SerializeField] float tileSize = 2f;

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
                float posX = -14.3f + (i * tileSize + x * tileSize) / 2f; // 2.34f, -0.18f - подобранные мною значения, чтобы этот грид
                float posY = -3.5f + (i * tileSize - x * tileSize) / 3.4f; //                и графический совпадали в пространстве

                newTile.transform.position = new Vector2(posX, posY);
                newTile.name = i + ", " + x;
            }
        }
    }

}
