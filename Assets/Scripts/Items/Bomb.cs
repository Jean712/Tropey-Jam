using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody rgbd;
    private SphereCollider sphc;

    public GameObject explosionParticle;
    public float blastRadius;
    [HideInInspector]
    public bool thrown;
    private GameObject[] allEnemies;
    private bool asHit = false;

    private void Awake()
    {
        GetComponent<GizmoCreator>().gizmoSize = blastRadius;

        rgbd = GetComponent<Rigidbody>();
        sphc = GetComponent<SphereCollider>();
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (thrown)
        {
            if (!asHit)
            {
                AOE();
            }

            asHit = true;
        }
    }

    private void AOE()
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);

        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject item in allEnemies)
        {
            if (blastRadius >= Vector3.Distance(transform.position, item.transform.position))
            {
                item.GetComponent<Enemy>().Death();
            }
        }
    }
}
