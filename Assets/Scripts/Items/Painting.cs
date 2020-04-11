using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    [HideInInspector]
    public bool thrown;
    public GameObject explosionParticle;
    public GameObject[] pieces;

    private void OnCollisionEnter(Collision collision)
    {
        if (thrown)
        {
            Vector3 position = transform.position;

            Instantiate(explosionParticle, position, transform.rotation);

            if (collision.gameObject.GetComponent<Enemy>() != null)
            {
                Vector3 position0 = transform.position + transform.right;
                Vector3 position1 = transform.position - transform.right;

                collision.gameObject.GetComponent<Enemy>().state = Enemy.guardState.Follow;

                Instantiate(pieces[0], position0, transform.rotation);
                Instantiate(pieces[1], position1, transform.rotation);

                Destroy(gameObject);
            }

            thrown = false;
        }
    }
}
