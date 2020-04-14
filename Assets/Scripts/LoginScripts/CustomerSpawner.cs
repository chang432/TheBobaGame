using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GM gameManager;
    public GameObject customer;
    private Patrol patrol;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnCustomers", 4f, 4f);
    }

    private void spawnCustomers()
    {
        //print("spawn");
        index = GM.customersInLine.Count;
        GameObject newcustomer = Instantiate(customer, transform.position, Quaternion.identity) as GameObject;
        newcustomer.name = "Customer_" + index;
        patrol = newcustomer.GetComponent<Patrol>();
        patrol.moving.x = -1;
        patrol.moving.y = 0;
        gameManager.addCustomerToLine(customer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 10);
    }
}
