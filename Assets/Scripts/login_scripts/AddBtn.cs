using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBtn : MonoBehaviour
{
    public GameObject customer;
    Patrol p;
    int index = 0;
    private void OnMouseDown()
    {
        //print("addbtn pressed");
        GameObject newcustomer = Instantiate(customer, new Vector3(327,-452,0), Quaternion.identity) as GameObject;
        //Instantiate(customer, new Vector3(327,-452,0), Quaternion.identity);
       	index++; 
        newcustomer.name = "customer_" + index;
        p = newcustomer.GetComponent<Patrol>();
        p.moving.x = -1;
        p.moving.y = 0;
    }
}
