using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class FreeFormBuildingManager : MonoBehaviour
{

    public BuildingTypeSO building;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
              Instantiate(building.prefab, hit.point, Quaternion.identity);
            }
            else
            {
                Instantiate(building.prefab, mouse, Quaternion.identity);
            }
           
        }
    }
    public void updateBuildingType(BuildingTypeSO building)
    {
        this.building = building;
    }
}
