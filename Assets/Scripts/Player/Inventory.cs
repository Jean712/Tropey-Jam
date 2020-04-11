using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inventory : MonoBehaviour
{
    Rigidbody rgbd;
    public Queue<GameObject> inventory;

    [Header("Debug")]
    public GameObject[] myInventory;
    public int inventoryValue;

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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            inventory.Enqueue(other.gameObject);
            myInventory = inventory.ToArray();

            if (other.GetComponent<Treasure>() != null)
            {
                inventoryValue = InventoryValue(myInventory);
            }

            other.gameObject.SetActive(false);
        }

        if (other.tag == "Exit")
        {
            GameObject[] finalInventory = inventory.ToArray();
            float finalValue = InventoryValue(finalInventory);
        }
    }

    public int InventoryValue(GameObject[] inventoryToCheck)
    {
        int value = 0;

        for (int i = 0; i < inventoryToCheck.Length; i++)
        {
            if (inventoryToCheck[i].GetComponent<Treasure>() != null)
            {
                value += inventoryToCheck[i].GetComponent<Treasure>().treasureValue;
            }
        }

        if (GetComponent<Player>().actualItem != null)
        {
            if (GetComponent<Player>().actualItem.GetComponent<Treasure>() != null)
            {
                value += GetComponent<Player>().actualItem.GetComponent<Treasure>().treasureValue;
            }
        }

        return value;
    }
}
