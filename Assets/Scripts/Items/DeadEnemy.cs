using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    AudioSource adsr;

    [HideInInspector]
    public bool thrown;
    public GameObject hitParticle;

    [Header("Audio")]
    public AudioClip hit;

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
            adsr.PlayOneShot(hit);

            if (collision.gameObject.GetComponent<Enemy>() != null)
            {
                collision.gameObject.GetComponent<Enemy>().state = Enemy.guardState.Follow;
            }

            thrown = false;
        }
    }
}
