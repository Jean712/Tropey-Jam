using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Des Tresors")]
    private int TreasuresSpawned;

    [SerializeField]
    private List<Transform> SpawnPositions;

    [SerializeField]
    private List<GameObject> Treasures;

    private void Start()
    {
        InstantiateTreasures();
    }

    private void InstantiateTreasures()
    {
        for (TreasuresSpawned = 0; TreasuresSpawned < Treasures.Count; TreasuresSpawned++)
            InstantiateTreasure();
    }

    private void InstantiateTreasure()
    {
        int SpawnTransformIndex = Random.Range(0, SpawnPositions.Count);
        Transform SpawnTransform = SpawnPositions[SpawnTransformIndex];

        int TreasureToSpawnIndex = Random.Range(0, Treasures.Count);
        GameObject TreasureToSpawn = Treasures[TreasureToSpawnIndex];

        Instantiate(TreasureToSpawn, SpawnTransform.position, SpawnTransform.rotation, SpawnTransform);

        Treasures.RemoveAt(TreasureToSpawnIndex);
        SpawnPositions.RemoveAt(SpawnTransformIndex);
    }
}
