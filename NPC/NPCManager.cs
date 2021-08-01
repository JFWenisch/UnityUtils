using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    public Vector3 startPoint;
    public Vector3 endPoint;
    public int zSpread = 25;
    public NPCTemplate newNpc;
    public int maxnpc = 50;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNpc", 5.0f, 5.0f);
    }

    void SpawnNpc()
    {
        if (counter < maxnpc)
        {
            Transform npcTransform = Instantiate(newNpc.prefab, startPoint, Quaternion.identity);
            NPCObject npc = npcTransform.gameObject.GetComponent<NPCObject>();
            npc.GoToTarget(endPoint);
            
            counter++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
      
    }
}
