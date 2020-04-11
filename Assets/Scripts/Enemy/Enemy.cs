using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Range(1,3)]
    public int state;
    public GameManager manager;
    NavMeshAgent agent;

    //TargetDetected
    Transform childTransform;
    DisplayFOV childFOV;
    public GameObject player;

    //Turn
    [Header("Turn Settings")]
    [Range(0, 360)]
    public float rotationAngle = 60;
    public float timing;
    float timer;
    bool droiteGauche = true;

    //Patrol
    [Header("Patrol Settings")]
    public Transform[] patrouilles;
    int a = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        childFOV = GetComponentInChildren<DisplayFOV>();
        childTransform = GetComponentInChildren<Transform>();
    }

    void Update()
    {
        switch (state)
        {
            case 1:
                //stay
                break;
            case 2:
                Turn();
                break;
            case 3:
                Patrol();
                break;
            default:
                Follow();
                break;
        }
        if (DetectTarget())
        {
            manager.GameOver();
            state = 0;
        }
    }

    void Turn()
    {
        timer += Time.deltaTime;
        if (timer >= timing)
        {
            if (droiteGauche == true)
            {
                transform.Rotate(Vector3.up, rotationAngle);
                droiteGauche = false;
            }
            else
            {
                transform.Rotate(Vector3.up, -rotationAngle);
                droiteGauche = true;
            }
            timer = 0;
        }
    }
    void Patrol()
    {
        if (DestinationReached())
        {
            SetNextDestination();
        }

        bool DestinationReached()
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void SetNextDestination()
        {
            a++;
            if (a >= patrouilles.Length)
            {
                a = 0;
            }
            agent.SetDestination(patrouilles[a].position);
        }
    }
    void Follow()
    {
        agent.SetDestination(player.transform.position);
    }
    bool DetectTarget()
    {
        Vector3 direction = player.transform.position - childTransform.position;
        float angle = Vector3.Angle(direction, childTransform.forward);
        if (angle < childFOV.viewAngle / 2)
        {
            RaycastHit hit;
            if (Physics.Raycast(childTransform.position, direction.normalized, out hit, childFOV.viewRadius))
            {
                if (hit.collider.gameObject == player)
                {
                    return true;
                }
            }
        }
        return false;
    }
}