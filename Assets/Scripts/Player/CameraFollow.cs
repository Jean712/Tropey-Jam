using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectToFollow;
    Vector3 offset;

    private void Awake()
    {
        offset = transform.position - objectToFollow.position;
    }

    private void Update()
    {
        transform.position = objectToFollow.position + offset;
    }
}

