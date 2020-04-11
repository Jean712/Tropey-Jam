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

    [SerializeField]
    private GameObject SpotLight;

    private void Start()
    {
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

        //InstantiateLight(SpawnedObject);

        Treasures.RemoveAt(TreasureToSpawnIndex);
        SpawnPositions.RemoveAt(SpawnTransformIndex);
    }
    /*
    private void InstantiateLight(GameObject LastTreasure)
    {
        Vector3 LightPos = LastTreasure.transform.position;
        Instantiate(SpotLight, LightPos.position, Quaternion.identity ,LastTreasure);
    }*/
}
