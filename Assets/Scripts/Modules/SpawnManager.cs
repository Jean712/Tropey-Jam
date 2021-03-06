﻿using System.Collections.Generic;
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
    public Vector3 tileOffset;
    private void Start()
    {
        for (int i = 0; i < nbModuleLargeur*nbModuleHauteur; i++)
        {
            AddModule();
        }
        Instantiate(moduleList[0], new Vector3(-10,0,0), Quaternion.identity, transform);
    }
    

    void AddModule()
    {
        GameObject tilePrefab = RandomModule();

        float moduleWidth = width;
        tileOffset.x += moduleWidth / 2;
        Instantiate(tilePrefab, tileOffset, Quaternion.identity, transform);

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
        int randomIndex = Random.Range(1, moduleList.Length);
        return moduleList[randomIndex];
    }
}
