using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectToFollow;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - objectToFollow.position;
    }
    void Update()
    {
        transform.position = objectToFollow.position + offset;
    }
}

