using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeFormBuildingMenuManager : MonoBehaviour
{
    public BuildingTypeSO building;
    public GridBuildingSystem manager;

    public void setBuildingType()
    {
        manager.updateBuildingType(building);
    }


    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            manager.updateBuildingType(building);
        });
            }

    // Update is called once per frame
    void Update()
    {

    }
}
