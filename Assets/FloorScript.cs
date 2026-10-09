using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public GameObject airplane;
    private Vector3 FloorVector; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(0, -3, airplane.transform.position.z+49000);
        this.gameObject.transform.localRotation = Quaternion.Euler(0, airplane.transform.localRotation.eulerAngles.y*-1, 0);
    }
}
