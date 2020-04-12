﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    BoxCollider boxc;
    AudioSource adsr;

    [HideInInspector]
    public bool thrown;
    public GameObject hitParticle;
    public GameObject explosionParticle;
    public GameObject[] pieces;

    [Header("Audio")]
    public AudioClip[] hits;
    public AudioClip explosion;

    private void Awake()
    {
        boxc = GetComponent<BoxCollider>();
        adsr = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (thrown)
        {
            Vector3 position = transform.position;

            if (collision.gameObject.GetComponent<Enemy>() != null)
            {
                Vector3 position0 = transform.position + transform.right;
                Vector3 position1 = transform.position - transform.right;
                Vector3 position2 = transform.position + transform.forward;
                Vector3 position3 = transform.position - transform.forward;

                collision.gameObject.GetComponent<Enemy>().state = Enemy.guardState.Follow;

                Instantiate(pieces[0], position0, transform.rotation);
                Instantiate(pieces[1], position1, transform.rotation);
                Instantiate(pieces[2], position0, transform.rotation);
                Instantiate(pieces[3], position1, transform.rotation);

                Instantiate(explosionParticle, position, transform.rotation);
                adsr.PlayOneShot(explosion);

                boxc.enabled = false;

                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }

                Destroy(gameObject, 1);
            }
            else
            {
                Instantiate(hitParticle, position, transform.rotation);
                adsr.PlayOneShot(hits[Random.Range(0, hits.Length)]);
            }

            thrown = false;
        }
    }
}
