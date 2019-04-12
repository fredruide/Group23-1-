using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    AIPathGrid grid;    

    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<AIPathGrid>();
    }

    void FindPath(Vector2 startPos, Vector2 targetPos)
    {
        Cell startCell = grid.CellFromWorldPoint(startPos);
        Cell targetCell = grid.CellFromWorldPoint(targetPos);

        List<Cell> openSet = new List<Cell>();
        HashSet<Cell> closeSet = new HashSet<Cell>();

        openSet.Add(startCell);

        while (openSet.Count > 0)
        {
            Cell currentCell = openSet[0];
            for (int i = 0; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentCell.fCost || openSet[i].fCost == currentCell.fCost && openSet[i].hCost < currentCell.hCost)
                    currentCell = openSet[i];

            }

            openSet.Remove(currentCell);
            closeSet.Add(currentCell);

            if (currentCell == targetCell)
            {
                RetraicePath(startCell, targetCell);
                return;
            }
                
            foreach (Cell neighbour in grid.GetNeighbours(currentCell))
            {
                if (neighbour.blocked || closeSet.Contains(neighbour))
                    continue;

                int newMovementCostWoNeighbour = currentCell.gCost + GetDistance(currentCell, neighbour);
                if(newMovementCostWoNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newMovementCostWoNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetCell);
                    neighbour.parent = currentCell;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
        }
    }

    void RetraicePath(Cell startCell, Cell endCell)
    {
        List<Cell> path = new List<Cell>();
        Cell currentCell = endCell;

        while (currentCell != startCell)
        {
            path.Add(currentCell);
            currentCell = currentCell.parent;
        }
        path.Reverse();
    }

    int GetDistance(Cell cellA, Cell cellB)
    {
        int dstX = Mathf.Abs(cellA.gridX - cellB.gridX);
        int dstY = Mathf.Abs(cellA.gridY - cellB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX-dstY);
        return 14 * dstX + 10 * (dstX-dstY);
    }
}
