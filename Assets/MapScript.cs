using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    Vector3 lastSave= new Vector3(0,0,-400);
    public GameObject airplane;
    public List<GameObject> LoadMaps;
    public List<GameObject> inActive;
    public GameObject coinSpwner;
    void Start()
    {
        int maplength = LoadMaps.Count;
        for (int i=0; i<5; i++)
        {
            int a =Random.Range(0, maplength);
            LoadMaps[a].SetActive(true);
            Instantiate(LoadMaps[a], lastSave, Quaternion.identity);
            lastSave.z += 600;
        }
        inActive.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastSave.z - airplane.transform.position.z < 1000)
        {
            int maplength = LoadMaps.Count;
            int a = Random.Range(0, maplength);
            LoadMaps[a].SetActive(true);
            Instantiate(LoadMaps[a], lastSave, Quaternion.identity);
            lastSave.z += 600;
        }
        if (inActive.Count != 0)
        {
            for (int i = 0; i < inActive.Count; i++)
            {
                if (Vector3.Distance(inActive[i].transform.position, airplane.transform.position) < 2000)
                {
                    inActive[i].SetActive(true);
                    inActive.RemoveAt(i);
                }
            }
            
        }

    }
}
