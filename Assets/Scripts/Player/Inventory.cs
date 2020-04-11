using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inventory : MonoBehaviour
{
    Rigidbody rgbd;
    public Queue<GameObject> inventory;

    public GameObject[] myInventory;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
        inventory = new Queue<GameObject>();
    }

    private void Update()
    {
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
            Debug.Log("lecul");

            inventory.Enqueue(other.gameObject);

            other.gameObject.SetActive(false);
        }
    }
}
