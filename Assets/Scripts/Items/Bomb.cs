using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody rgbd;
    SphereCollider sphc;
    MeshRenderer mshr;
    AudioSource adsr;

    public GameObject explosionParticle;
    public float blastRadius;
    [HideInInspector]
    public bool thrown;
    GameObject[] allEnemies;

    [Header("Audio")]
    public AudioClip explosion;

    private void Awake()
    {
        GetComponent<GizmoCreator>().gizmoSize = blastRadius;

        rgbd = GetComponent<Rigidbody>();
        sphc = GetComponent<SphereCollider>();
        mshr = GetComponentInChildren<MeshRenderer>();
        adsr = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collider)
    {
        bool asHit = false;

        if (thrown)
        {
            if (!asHit)
            {
                AOE();

                sphc.enabled = false;
                mshr.enabled = false;
            }

            asHit = true;
        }
    }

    private void AOE()
    {
        Vector3 position = transform.position;

        Instantiate(explosionParticle, position, transform.rotation);
        adsr.PlayOneShot(explosion);

        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject item in allEnemies)
        {
            if (blastRadius >= Vector3.Distance(transform.position, item.transform.position))
            {
                item.GetComponent<Enemy>().Death();
            }
        }

        Destroy(gameObject, 1);
    }
}
