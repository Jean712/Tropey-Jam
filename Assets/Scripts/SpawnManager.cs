using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Des Tresors")]
    [SerializeField]
    private int TreasuresToSpawn;
    private int TreasuresSpawned;
    [SerializeField]
    private Transform[] SpawnPositions;
    [SerializeField]
    private GameObject[] Treasures;



    void Start()
    {
        for (TreasuresSpawned = 0; TreasuresSpawned < TreasuresToSpawn; TreasuresSpawned++)
        {
            int SpawnTransIndex = Random.Range(0, SpawnPositions.Length);
            Transform SpawnTrans = SpawnPositions[SpawnTransIndex].transform;
            float SpawnX = SpawnTrans.transform.position.x;
            float SpawnY = SpawnTrans.transform.position.y;
            float SpawnZ = SpawnTrans.transform.position.z;
            Vector3 SpawnVector = new Vector3(SpawnX, SpawnY, SpawnZ);
            
            //Instantiate Trésor sur la position
            int TreasureToSpawnIndex = Random.Range(0, Treasures.Length);
            GameObject TreasureToSpawn = Treasures[TreasureToSpawnIndex].gameObject;
            Instantiate(TreasureToSpawn, SpawnVector, Quaternion.identity);

            //Suppr position
        }
    }

    void Update()
    {
        
    }
}
