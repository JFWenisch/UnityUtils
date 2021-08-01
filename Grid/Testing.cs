using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    private GridSystem<SimpleGridObject> grid;
    // Start is called before the first frame update
    void Start()
    {
         grid = new GridSystem<SimpleGridObject>(20, 10, 10f, Vector3.zero, (GridSystem<SimpleGridObject> g, int x, int y)=> new SimpleGridObject(g,x,y));
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
            Vector3 positon = getMousePosition();
            SimpleGridObject currentGridObject = grid.GetObject(positon);
            if(currentGridObject!=null)
            {
                currentGridObject.add();
            }
          
        }
        
    }
}
