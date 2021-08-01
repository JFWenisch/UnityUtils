using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButton : MonoBehaviour
{
    public GameObject newNpc;
    public void SpawnNPC()
    {
        Instantiate(newNpc);
       
    }
}
