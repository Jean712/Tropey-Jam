using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    [Header("Spawn Des Tresors")]
    private int TreasuresSpawned;

    private float TreasuresToSpawn;

    [SerializeField]
    private List<Transform> SpawnPositions = new List<Transform>();

    [SerializeField]
    private List<GameObject> Treasures = new List<GameObject>();

    void Start()
    {
        transform.Rotate(Vector3.up, 90 * Random.Range(0, 4));
        TreasuresToSpawn = Treasures.Count;
        InstantiateTreasures();
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

        GameObject SpawnedObject = Instantiate(TreasureToSpawn, SpawnTransform.position, SpawnTransform.rotation);

        Treasures.RemoveAt(TreasureToSpawnIndex);
        SpawnPositions.RemoveAt(SpawnTransformIndex);
    }
}
