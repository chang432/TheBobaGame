using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GM gameManager;
    public GameObject customer;
    public Patrol patrol;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("spawnCustomers", 4f, 4f);
        //InvokeRepeating("moveCustomers", 1.0f, 1.0f);
    }

    private void spawnCustomers()
    {
        print("spawn");
        index = GM.customersInLine.Count;
        GameObject newcustomer = Instantiate(customer, new Vector3(327, -452, 0), Quaternion.identity) as GameObject;
        newcustomer.name = "Customer_" + index;
        patrol = newcustomer.GetComponent<Patrol>();
        patrol.moving.x = -1;
        patrol.moving.y = 0;
        gameManager.addCustomerToLine(customer);
    }

    private void moveCustomers()
    {
        print("move");
    }
    
}
