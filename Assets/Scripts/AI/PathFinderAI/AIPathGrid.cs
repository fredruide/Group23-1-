using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPathGrid : MonoBehaviour
{
    public LayerMask pathBlocked;
    public Vector2 gridWorldSize;
    public float cellRadius;
    Cell[,] grid;

    float cellDiameter;
    int gridSizeX, gridSizeY;

    private void Start()
    {
        cellDiameter = cellRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / cellDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / cellDiameter);

        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Cell[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * cellDiameter + cellRadius) + Vector3.up * (y * cellDiameter + cellRadius);
                bool blocked = Physics.CheckSphere(worldPoint, cellRadius, pathBlocked);
                //grid[x, y] = new Cell(blocked, worldPoint);
                grid[x, y] = ScriptableObject.CreateInstance<Cell>();
                grid[x, y].CellInit(blocked, worldPoint);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, gridWorldSize);

        if(grid != null)
        {
            foreach (Cell cell in grid)
            {
                //Debug.Log(cell.blocked);
                Gizmos.color = cell.blocked ? Color.red : Color.blue;
                Gizmos.DrawCube(cell.worldPosistion, Vector2.one * (cellDiameter - 0.1f));
            }
        }
    }
}
