using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : ScriptableObject
{
    public bool blocked;
    public Vector2 worldPosistion;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;
    public Cell parent;

    public void CellInit(bool _blocked, Vector2 _worldPos, int _gridX, int _gridY)
    {
        blocked = _blocked;
        worldPosistion = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost
    {
        get { return gCost + hCost; }
    }
}
