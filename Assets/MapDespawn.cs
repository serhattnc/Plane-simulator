using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapDespawn : MonoBehaviour
{
    public GameObject airplane;

    void Update()
    {
     if(Vector3.Distance(airplane.transform.position, this.transform.position)>2000 && airplane.transform.position.z> this.transform.position.z)
        {
            GameObject.Find("Map").GetComponent<MapScript>().inActive.Add(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
