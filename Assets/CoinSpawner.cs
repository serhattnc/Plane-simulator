using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public int coinAnzahl;
    public GameObject coin;
    void Start()
    {
        coinAnzahl = Random.RandomRange(10, 20);
        for (int i=0;i<coinAnzahl;i++)
        {
            coin.transform.position = new Vector3(Random.RandomRange(-200f, 250f), Random.RandomRange(0f, 350f), Random.RandomRange(0f, -500f));
            Instantiate(coin);
        }
    }


    void Update()
    {
        
    }
}
