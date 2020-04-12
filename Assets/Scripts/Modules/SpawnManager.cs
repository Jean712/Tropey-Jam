using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour
{
    
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
