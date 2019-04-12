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
                //bool blocked = Physics.CheckSphere(worldPoint, cellRadius, pathBlocked);
                bool blocked = Physics2D.OverlapCircle(worldPoint, cellRadius, pathBlocked);
                //grid[x, y] = new Cell(blocked, worldPoint);
                grid[x, y] = ScriptableObject.CreateInstance<Cell>();
                grid[x, y].CellInit(blocked, worldPoint, x, y);
            }
        }

    }

    public List<Cell> GetNeighbours(Cell cell)
    {
        List<Cell> neighbours = new List<Cell>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = cell.gridX + x;
                int checkY = cell.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                    neighbours.Add(grid[checkX,checkY]);
            }
        }

        return neighbours;
    }

    public Cell CellFromWorldPoint(Vector2 worldPosistion)
    {
        float percentX = (worldPosistion.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosistion.y + gridWorldSize.y / 2) / gridWorldSize.y;

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

        return grid[x, y];
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
