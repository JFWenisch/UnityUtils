using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float camSpeed = 20f;
    public float scrollSpeed = 20f;
    public float camBorderThickness = 10f;
    private Vector3 camPosition ;
    private Quaternion camRotation ;
    // Start is called before the first frame update
    void Start()
    {
    camPosition = transform.position;
   camRotation = transform.rotation;
}

    // Update is called once per frame
    void Update()
    {
         camPosition = transform.position;
         camRotation = transform.rotation;

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - camBorderThickness)
        {
            camPosition.z += camSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= 0- camBorderThickness)
        {
            camPosition.z -= camSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x>= Screen.width - camBorderThickness)
        {
            camPosition.x += camSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= 0 - camBorderThickness)
        {
            camPosition.x -= camSpeed * Time.deltaTime;
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel");
        camPosition.y -= scroll * scrollSpeed * 200f * Time.deltaTime;


        transform.position = camPosition;


        if (Input.GetKey(KeyCode.Q))
             {

            transform.Rotate(0, camSpeed * Time.deltaTime, 0, Space.World);
               //  transform.rotation = Quaternion.Euler(camRotation.x +5 , camRotation.y, camRotation.z);
             }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, -camSpeed * Time.deltaTime, 0, Space.World);

        }
            // transform.rotation = Quaternion.Euler(camRotation.x - 5 , camRotation.y, camRotation.z);
     
        /* 
         if (Input.GetKey(KeyCode.Q))
         {


             camRotation *= Quaternion.Euler(Vector3.up * 5);
         }
         if (Input.GetKey(KeyCode.Q))
         {

             camRotation *= Quaternion.Euler(Vector3.up * -5);
         }
         transform.rotation = Quaternion.Lerp(transform.rotation, camRotation, Time.deltaTime * camSpeed);
          */
       


    }
}
