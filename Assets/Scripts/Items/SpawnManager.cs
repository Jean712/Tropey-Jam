using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Des Tresors")]
    private int TreasuresSpawned;
    
    private float TreasuresToSpawn;

    [SerializeField]
    private List<Transform> SpawnPositions;

    [SerializeField]
    private List<GameObject> Treasures;

    private void Start()
    {
        TreasuresToSpawn = Treasures.Count;
        InstantiateTreasures();
        Debug.Log(TreasuresToSpawn);
    }

    private void InstantiateTreasures()
    {
        for (TreasuresSpawned = 0; TreasuresSpawned < TreasuresToSpawn; TreasuresSpawned++)
            InstantiateTreasure();
    }

    private void InstantiateTreasure()
    {
        int SpawnTransformIndex = Random.Range(0, SpawnPositions.Count);
        Transform SpawnTransform = SpawnPositions[SpawnTransformIndex];

        int TreasureToSpawnIndex = Random.Range(0, Treasures.Count);
        GameObject TreasureToSpawn = Treasures[TreasureToSpawnIndex];

        Instantiate(TreasureToSpawn, SpawnTransform.position, SpawnTransform.rotation);

        Treasures.RemoveAt(TreasureToSpawnIndex);
        SpawnPositions.RemoveAt(SpawnTransformIndex);
    }
}
