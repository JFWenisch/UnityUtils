using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridSystem<GridObject> : MonoBehaviour
{

    private int width;
    private int height;
    private float cellsize;
    private GridObject[,] array;
    public bool showDebug = true;
    private Vector3 originPosition;

    public event EventHandler<OnGridValueChangedEventArgs> onGridValueChanged;
    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }
    public float getCellSize()
    {
        return cellsize;
    }
    // Start is called before the first frame update
    public GridSystem(int width, int height, float cellSize, Vector3 position, Func<GridSystem<GridObject>, int , int , GridObject> createGridObject)
    {
        this.width = width;
        this.height = height;
        this.cellsize = cellSize;
        this.originPosition = position;
     
        array = new GridObject[width, height];
        for (int x = 0; x < array.GetLength(0); x++)
        {
            for (int y = 0; y < array.GetLength(1); y++)
            {
                array[x, y] = createGridObject(this,x,y);
            }
        }

        if (showDebug)
        {
            TextMesh[,] debugTextArray = new TextMesh[width, height];
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                //    debugTextArray[x, y] = UtilsClass.CreateWorldText(array[x, y].ToString(),null, GetWorldPosition(x, y) + new Vector3(cellsize, 0, cellsize) * .5f, 10, Color.white, TextAnchor.MiddleCenter);

                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x , y +1), Color.white, 100f);
                }
            }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width,height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(width,0), GetWorldPosition(width, height), Color.white, 100f);
            onGridValueChanged += (object sender, OnGridValueChangedEventArgs eventArgs) =>
              {
                 // debugTextArray[eventArgs.x, eventArgs.y].text = array[eventArgs.x, eventArgs.y].ToString();
              };
        }
    }


        public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, 0, y) * cellsize + originPosition;
    }

    public void SetValue(int x, int y, GridObject value)
    {
        Debug.Log("width" + width + " " + "height" + " " + height);
        Debug.Log(x + " " + y + " " + value);
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            array[x, y] = value;
            if (onGridValueChanged != null) onGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
        }

    }
    public void TriggerGridObjectChanged(int x, int y)
    {
        if (onGridValueChanged != null) onGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
    }
    public GridObject GetObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return array[x, y];
        }
        else
        {
            return default;
        }

    }
    public GridObject GetObject(Vector3 position)
    {
        int x, y;
        GetXY(position, out x, out y);
        return GetObject(x, y);
    }

    public void GetXY(Vector3 position, out int x, out int y)
    {
        x = Mathf.FloorToInt((position- originPosition).x/ cellsize);
        y = Mathf.FloorToInt((position - originPosition).z / cellsize);
    }
    public void SetObject(Vector3 position, GridObject value)
    {
        int x, y;
        GetXY(position, out x, out y);
        SetValue(x, y, value);
    }

}
