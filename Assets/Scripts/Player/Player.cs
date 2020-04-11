using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public LayerMask walkable;
    NavMeshAgent agent;

    [Range(0, -90)]
    public float shootingAngle;
    public float initialBoost;
    Transform target;

    public GameObject actualItem;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        target = transform.Find("Target");
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (Physics.Raycast(ray, out hit, 100, walkable))
            {
                agent.SetDestination(hit.point);
                agent.isStopped = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out hit, 100, walkable))
            {
                float initialForce;
                float distance = Vector3.Distance(transform.position, hit.point);

                if (actualItem != null)
                {
                    transform.LookAt(hit.point);

                    actualItem.SetActive(true);
                    actualItem.transform.position = target.position;
                    actualItem.transform.rotation = target.rotation;

                    if (actualItem.GetComponent<Bomb>() != null)
                    {
                        actualItem.GetComponent<Bomb>().thrown = true;
                    }

                    actualItem.GetComponent<Rigidbody>().isKinematic = false;
                    actualItem.GetComponent<Rigidbody>().useGravity = true;

                    initialForce = Mathf.Sqrt((distance / Mathf.Sin(2 * shootingAngle)) * Physics.gravity.magnitude) * initialBoost;
                    actualItem.GetComponent<Rigidbody>().AddForce(transform.forward * initialForce, ForceMode.Impulse);

                    actualItem = null;
                }
            }

            GetComponent<Inventory>().myInventory = GetComponent<Inventory>().inventory.ToArray();
            GetComponent<Inventory>().inventoryValue = GetComponent<Inventory>().InventoryValue(GetComponent<Inventory>().myInventory);
        }
    }
}
