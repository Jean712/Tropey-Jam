using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoPlayer : MonoBehaviour
{
    private Rigidbody rgbd;
    public float speed;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            rgbd.velocity += new Vector3(0, 0, 1 * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rgbd.velocity += new Vector3(0, 0, -1 * speed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            rgbd.velocity += new Vector3(-1 * speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rgbd.velocity += new Vector3(1 * speed, 0, 0);
        }
    }
}
