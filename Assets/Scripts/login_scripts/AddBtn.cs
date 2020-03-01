using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBtn : MonoBehaviour
{
    [SerializeField]
    public GM GameManager;

    public GameObject customer;
    Patrol p;
    int index = 1;
    private void OnMouseDown()
    {
        //print("addbtn pressed");
        GameObject newcustomer = Instantiate(customer, new Vector3(327,-452,0), Quaternion.identity) as GameObject;
        //Instantiate(customer, new Vector3(327,-452,0), Quaternion.identity);
        newcustomer.name = "Customer_" + index;
        index++; 
        p = newcustomer.GetComponent<Patrol>();
        p.moving.x = -1;
        p.moving.y = 0;
        GameManager.addCustomer(customer);
    }
}
