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

                case "DeadEnemy(Clone)":
                    itemList[1].SetActive(true);
                    break;

                case "Bomb(Clone)":
                    itemList[2].SetActive(true);
                    break;

                case "PaintingGreen(Clone)":
                    itemList[3].SetActive(true);
                    break;

                case "PaintingPink(Clone)":
                    itemList[4].SetActive(true);
                    break;

                case "PaintingSwedish(Clone)":
                    itemList[5].SetActive(true);
                    break;

                case "PaintingBrokenGreen(Clone)":
                    itemList[6].SetActive(true);
                    break;

                case "PaintingBrokenGreenReverse(Clone)":
                    itemList[7].SetActive(true);
                    break;

                case "PaintingBrokenPink(Clone)":
                    itemList[8].SetActive(true);
                    break;

                case "PaintingBrokenPinkReverse(Clone)":
                    itemList[9].SetActive(true);
                    break;

                case "PaintingBrokenSwedish(Clone)":
                    itemList[10].SetActive(true);
                    break;

                case "PaintingBrokenSwedishReverse(Clone)":
                    itemList[11].SetActive(true);
                    break;

                case "Toilet(Clone)":
                    itemList[12].SetActive(true);
                    break;

                case "ToiletBroken1(Clone)":
                    itemList[13].SetActive(true);
                    break;

                case "ToiletBroken2(Clone)":
                    itemList[14].SetActive(true);
                    break;

                case "Cars(Clone)":
                    itemList[15].SetActive(true);
                    break;

                case "CarBlue(Clone)":
                    itemList[16].SetActive(true);
                    break;

                case "CarGreen(Clone)":
                    itemList[17].SetActive(true);
                    break;

                case "CarPink(Clone)":
                    itemList[18].SetActive(true);
                    break;

                case "CarYellow(Clone)":
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
