using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BuildingTypeSO : ScriptableObject
{
    public Transform prefab;
    public int width;
    public int height;
    public string nameString;

    public enum Direction
    {
        Down,Left, Up, Right
    }
    public static Direction getNextDirection(Direction dir)
    {
        switch(dir)
        {
            default:
            case Direction.Down: return Direction.Left;
            case Direction.Left: return Direction.Up;
            case Direction.Up: return Direction.Right;
            case Direction.Right: return Direction.Down;
        }
    }
    public static int getRotationAngle(Direction dir)
    {
        switch(dir)
        {
            default:
            case Direction.Down: return 0;
            case Direction.Left: return 90;
            case Direction.Up: return 180;
            case Direction.Right: return 270;
        }
    }

    public  Vector2Int getRotationOffset(Direction dir)
    {
        switch(dir)
        {
            default:
            case Direction.Down: return new Vector2Int(0,0);
            case Direction.Left: return new Vector2Int(0, width);
            case Direction.Up: return new Vector2Int(width, height);
            case Direction.Right: return new Vector2Int(height, 0);
        }
    }
    public List<Vector2Int> getGridPositionList(Vector2Int offset, Direction dir)
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>();
        switch(dir)
        {
            default:
            case Direction.Down:
            case Direction.Up:
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        gridPositionList.Add(offset + new Vector2Int(x, y));
                    }
                }
                break;
            case Direction.Left:
            case Direction.Right:
                for (int x = 0; x < height; x++)
                {
                    for (int y = 0; y < width; y++)
                    {
                        gridPositionList.Add(offset + new Vector2Int(x, y));
                    }
                }
                break;
        }
       
        return gridPositionList;
    }
}
