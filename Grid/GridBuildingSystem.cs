using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridBuildingSystem : MonoBehaviour
{
    public int width= 10;
    public int height= 10;
    public float cellSize = 10f;
    private GridSystem<GridObject> grid;
    public BuildingTypeSO building;
    private BuildingTypeSO.Direction dir = BuildingTypeSO.Direction.Down;
    void Start()
    {
        grid = new GridSystem<GridObject>(width, height, cellSize, transform.position, (GridSystem<GridObject> g, int x, int y) => new GridObject(g, x, y));
    }
    public static Vector3 getMousePosition()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            return hit.point;
        }
        else
        {
            return mouse;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int mouseX, mouseY;
            grid.GetXY(getMousePosition(), out mouseX, out mouseY);
            List<Vector2Int> buildingOccupation = building.getGridPositionList(new Vector2Int(mouseX, mouseY),dir);
            foreach (Vector2Int gridPosition in buildingOccupation)
            {
                GridObject daObject = grid.GetObject(gridPosition.x, gridPosition.y);
                if(daObject == null)
                {
                    UtilsClass.CreateWorldTextPopup("You cannot build outside of the grid", getMousePosition());
                    return;
                }
                if (!daObject.canBuild())
                {
                    UtilsClass.CreateWorldTextPopup("Cannot build here", getMousePosition());
                    return;
                }
            }
            GridObject curObject = grid.GetObject(getMousePosition());
            if(curObject != null)
            {
                Vector2Int rotationOffset = building.getRotationOffset(dir);
                Vector3 placedObjectPosition = grid.GetWorldPosition(mouseX, mouseY)+ new Vector3(rotationOffset.x, 0, rotationOffset.y)*grid.getCellSize();
                    Transform curBuilding = Instantiate(building.prefab, grid.GetWorldPosition(mouseX, mouseY), Quaternion.Euler(0,BuildingTypeSO.getRotationAngle(dir),0));
                    foreach(Vector2Int gridPosition in buildingOccupation)
                    {
                        grid.GetObject(gridPosition.x, gridPosition.y).setTransform(curBuilding);
                    }
               
            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            dir = BuildingTypeSO.getNextDirection(dir);
            UtilsClass.CreateWorldTextPopup(""+dir, getMousePosition());
        }
    }
    public void updateBuildingType(BuildingTypeSO building)
    {
        this.building = building;
    }
    public class GridObject
    {
        private Transform transform;
        private GridSystem<GridObject> grid;
        private int x;
        private int y;

        public GridObject(GridSystem<GridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }

        public void setTransform( Transform transform)
        {
            this.transform = transform;
            grid.TriggerGridObjectChanged(x, y);
        }

        public bool canBuild()
        {
            return transform == null;
        }

        public Transform getTransform()
        {
            return transform;
        }
        public void clear()
        {
            transform = null;
        }

        public override string ToString()
        {
            return x+", "+y +"\n"+ transform;
        }

    }
}
