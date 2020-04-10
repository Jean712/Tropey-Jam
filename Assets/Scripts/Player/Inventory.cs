using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inventory : MonoBehaviour
{
    Rigidbody rgbd;
    Queue inventory;

    public LayerMask walkable;
    NavMeshAgent agent;

    public float speed;
    public float maxSpeed;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
        inventory = new Queue();

        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        rgbd.velocity = Vector3.Lerp(rgbd.velocity, Vector3.zero, 0.05f);

        if (Input.GetKey(KeyCode.Z))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D))
        {
            rgbd.velocity += transform.forward * speed;
        }

        rgbd.velocity = Vector3.ClampMagnitude(rgbd.velocity, maxSpeed);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (Physics.Raycast(ray, out hit, 100, walkable))
            {
                agent.SetDestination(hit.point);
                agent.isStopped = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            inventory.Enqueue(other.gameObject);

            Destroy(other.gameObject);
        }
    }
}
