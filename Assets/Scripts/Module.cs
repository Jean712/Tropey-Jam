using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{   
    void Start()
    {
        transform.Rotate(Vector3.up, 90 * Random.Range(0, 4));
    }
}
