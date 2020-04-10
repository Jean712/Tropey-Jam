using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inventory : MonoBehaviour
{
    Rigidbody rgbd;
    public Queue<GameObject> inventory;

    public GameObject[] myInventory;

    //public float speed;
    //public float maxSpeed;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
        inventory = new Queue<GameObject>();
    }

    private void Update()
    {
        //rgbd.velocity = Vector3.Lerp(rgbd.velocity, Vector3.zero, 0.05f);

        //if (Input.GetKey(KeyCode.Z))
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        //}

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        //}

        //if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D))
        //{
        //    rgbd.velocity += transform.forward * speed;
        //}

        //rgbd.velocity = Vector3.ClampMagnitude(rgbd.velocity, maxSpeed);

        if (inventory.Count >= 1)
        {
            if (GetComponent<Player>().actualItem == null)
            {
                GetComponent<Player>().actualItem = inventory.Dequeue();
            }
        }

        myInventory = inventory.ToArray();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            inventory.Enqueue(other.gameObject);

            other.gameObject.SetActive(false);
        }
    }
}
