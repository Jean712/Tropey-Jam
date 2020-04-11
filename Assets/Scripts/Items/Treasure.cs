using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int treasureValue;
    public GameObject[] pieces;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Vector3 position0 = transform.position + transform.right;
            Vector3 position1 = transform.position - transform.right;

            collision.gameObject.GetComponent<Enemy>().state = Enemy.guardState.Follow;

            Instantiate(pieces[0], position0, transform.rotation);
            Instantiate(pieces[1], position1, transform.rotation);

            Destroy(gameObject);
        }
    }
}
