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

    [Header("Modules")]
    public GameObject[] moduleList;
    public int nbModuleLargeur;
    public int nbModuleHauteur;
    public float width;
    public float heigth;
    private int roomNb;
    private List<GameObject> addedModule;
    public Vector3 tileOffset;
    private void Start()
    {
        addedModule = new List<GameObject>();
        for (int i = 0; i < nbModuleLargeur*nbModuleHauteur; i++)
        {
            AddModule();
        }
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

    void AddModule()
    {
        GameObject tilePrefab = RandomModule();

        float moduleWidth = width;
        tileOffset.x += moduleWidth / 2;

        GameObject newModule = Instantiate(tilePrefab, tileOffset, Quaternion.identity, transform);
        addedModule.Add(newModule);

        tileOffset.x += moduleWidth / 2;

        roomNb += 1;

        if (roomNb == nbModuleLargeur)
        {
            tileOffset.z += heigth;
            tileOffset.x = 0;
            roomNb = 0;
        }
    }

    GameObject RandomModule()
    {
        int randomIndex = Random.Range(0, moduleList.Length);
        return moduleList[randomIndex];
    }
}
