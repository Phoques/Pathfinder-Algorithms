using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridLayout : MonoBehaviour
{
    GridLayoutGroup grid;

    private void Start()
    {
        grid = GetComponent<GridLayoutGroup>();

        grid.cellSize = new Vector2(1.1f, 1.1f);
        grid.startCorner = GridLayoutGroup.Corner.UpperLeft;
        grid.startAxis = GridLayoutGroup.Axis.Horizontal;
        grid.childAlignment = TextAnchor.MiddleCenter;
        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = 4;
    }
}
