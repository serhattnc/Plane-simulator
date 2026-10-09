using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour
{
    public GameObject plane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 4f * Time.deltaTime, 0f);
        if (this.transform.position.x-plane.transform.position.x>=500)
        {
            this.gameObject.SetActive(false);
        }
    }
}
