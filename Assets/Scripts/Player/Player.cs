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
    public GameObject[] itemList;
    Transform target;

    public GameObject actualItem;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = transform.Find("Target");

        for (int i = 0; i < itemList.Length; i++)
        {
            itemList[i].SetActive(false);
        }
    }

    void Update()
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            itemList[i].SetActive(false);
        }

        if (actualItem != null)
        {
            string itemName = actualItem.name;

            switch (itemName)
            {
                case "Gun":
                    itemList[0].SetActive(true);
                    break;

                case "DeadEnemy":
                    itemList[1].SetActive(true);
                    break;

                case "Bomb":
                    itemList[2].SetActive(true);
                    break;

                case "PaintingGreen":
                    itemList[3].SetActive(true);
                    break;

                case "PaintingPink":
                    itemList[4].SetActive(true);
                    break;

                case "PaintingSwedish":
                    itemList[5].SetActive(true);
                    break;

                case "PaintingBrokenGreen":
                    itemList[6].SetActive(true);
                    break;

                case "PaintingBrokenGreenReverse":
                    itemList[7].SetActive(true);
                    break;

                case "PaintingBrokenPink":
                    itemList[8].SetActive(true);
                    break;

                case "PaintingBrokenPinkReverse":
                    itemList[9].SetActive(true);
                    break;

                case "PaintingBrokenSwedish":
                    itemList[10].SetActive(true);
                    break;

                case "PaintingBrokenSwedishReverse":
                    itemList[11].SetActive(true);
                    break;

                case "Toilet":
                    itemList[12].SetActive(true);
                    break;

                case "ToiletBroken1":
                    itemList[13].SetActive(true);
                    break;

                case "ToiletBroken2":
                    itemList[14].SetActive(true);
                    break;

                case "Cars":
                    itemList[15].SetActive(true);
                    break;

                case "CarBlue":
                    itemList[16].SetActive(true);
                    break;

                case "CarGreen":
                    itemList[17].SetActive(true);
                    break;

                case "CarPink":
                    itemList[18].SetActive(true);
                    break;

                case "CarYellow":
                    itemList[19].SetActive(true);
                    break;
            }
        }

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

                    if (actualItem.GetComponent<Gun>() != null)
                    {
                        actualItem.GetComponent<Gun>().thrown = true;
                    }

                    if (actualItem.GetComponent<DeadEnemy>() != null)
                    {
                        actualItem.GetComponent<DeadEnemy>().thrown = true;
                    }

                    if (actualItem.GetComponent<Painting>() != null)
                    {
                        actualItem.GetComponent<Painting>().thrown = true;
                    }

                    if (actualItem.GetComponent<Toilet>() != null)
                    {
                        actualItem.GetComponent<Toilet>().thrown = true;
                    }

                    if (actualItem.GetComponent<Cars>() != null)
                    {
                        actualItem.GetComponent<Cars>().thrown = true;
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
