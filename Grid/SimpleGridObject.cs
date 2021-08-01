using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGridObject
{
    private GridSystem<SimpleGridObject> grid;
    private int counter = 0;
    private int x;
    private int y;

    public SimpleGridObject(GridSystem<SimpleGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void add()
    {
        counter++;
        grid.TriggerGridObjectChanged(x,y);
    }

    public override string ToString()
    {
        return counter.ToString();
    }
}
