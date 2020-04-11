using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [HideInInspector]
    public bool thrown;
    public GameObject explosionParticle;

    private void OnCollisionEnter(Collision collision)
    {
        if (thrown)
        {
            Vector3 position = transform.position;

            Instantiate(explosionParticle, position, transform.rotation);

            if (collision.gameObject.GetComponent<Enemy>() != null)
            {
                collision.gameObject.GetComponent<Enemy>().state = Enemy.guardState.Follow;
            }

            thrown = false;
        }
    }
}
