using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : ScriptableObject
{
    public bool blocked;
    public Vector2 worldPosistion;

    public void CellInit(bool _blocked, Vector2 _worldPos)
    {
        blocked = _blocked;
        worldPosistion = _worldPos;
    }
}
