using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public LayerMask walkable;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
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
}
