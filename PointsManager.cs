using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text valueText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        valueText.text = GlobalManager.points.ToString();
    }
}
