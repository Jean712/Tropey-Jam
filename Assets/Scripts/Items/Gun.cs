using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    AudioSource adsr;

    [HideInInspector]
    public bool thrown;
    public GameObject hitParticle;

    [Header("Audio")]
    public AudioClip[] hits;

    private void Awake()
    {
        adsr = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (thrown)
        {
            Vector3 position = transform.position;

            Instantiate(hitParticle, position, transform.rotation);
            adsr.PlayOneShot(hits[Random.Range(0, hits.Length)]);

            if (collision.gameObject.GetComponent<Enemy>() != null)
            {
                collision.gameObject.GetComponent<Enemy>().Death();
            }

            thrown = false;
        }
    }
}
