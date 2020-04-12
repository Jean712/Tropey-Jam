using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum guardState { Stay, Turn, Patrol, Follow };

    public guardState state;
    NavMeshAgent agent;
    BoxCollider boxc;
    MeshRenderer mshr;
    AudioSource adsr;

    Transform childTransform;
    DisplayFOV childFOV;
    GameObject player;
    public GameObject deadBody;

    [Header("Turn Settings")]
    [Range(0, 360)]
    public float rotationAngle = 60;
    public float timing;
    float timer;
    bool droiteGauche = true;
    bool starting;

    [Header("Patrol Settings")]
    public Transform[] patrouilles;
    int a = 0;

    [Header("Audio")]
    public AudioClip death;

    void Start()
    {
        player = GameObject.Find("Player").gameObject;
        agent = GetComponent<NavMeshAgent>();
        boxc = GetComponent<BoxCollider>();
        mshr = GetComponentInChildren<MeshRenderer>();
        adsr = GetComponent<AudioSource>();
        childFOV = GetComponentInChildren<DisplayFOV>();
        childTransform = GetComponentInChildren<Transform>();

        StartCoroutine(Starting(0.7f));
    }

    void Update()
    {
        if (starting)
        {
            switch (state)
            {
                case guardState.Stay:
                    // Stay();
                    break;
                case guardState.Turn:
                    Turn();
                    break;
                case guardState.Patrol:
                    Patrol();
                    break;
                case guardState.Follow:
                    Follow();
                    break;
            }
        }

        if (DetectTarget())
        {
            state = guardState.Follow;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<Player>().GameOver();
        }
    }

    public void Death()
    {
        Vector3 position = transform.position;

        Instantiate(deadBody, position, transform.rotation);
        adsr.PlayOneShot(death);

        boxc.enabled = false;
        mshr.enabled = false;
        GetComponent<DisplayFOV>().viewAngle = 0;

        Destroy(gameObject, 1);
    }

    IEnumerator Starting(float time)
    {
        yield return new WaitForSeconds(time);

        starting = true;
    }
}