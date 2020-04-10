using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManaher : MonoBehaviour
{
    [Header("Spawn Des Tresors")]
    [SerializeField]
    private int TreasuresToSpawn;
    [SerializeField]
    private int TreasuresSpawned;
    private Transform[] SpawnPositions;
    [SerializeField]
    private GameObject[] Treasures;



    void Start()
    {
        for (TreasuresSpawned = 0; TreasuresSpawned < TreasuresToSpawn; TreasuresSpawned++)
        {
            //Définir pos random
            //Instantiate Trésor sur la position
            //Suppr position
        }
    }

    void Update()
    {
        
    }
}
