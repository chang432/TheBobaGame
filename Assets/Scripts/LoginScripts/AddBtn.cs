using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBtn : MonoBehaviour
{
    [SerializeField]
    public GM GameManager;

    public GameObject customer;
    public Patrol p;
    public Animator a;
    int index;
    private void OnMouseDown()
    {
        //print("addbtn pressed");
        index = GM.customersInLine.Count;
        GameObject newcustomer = Instantiate(customer, GameObject.Find("CustomerSpawner").transform.position, Quaternion.identity) as GameObject;
        newcustomer.name = "Customer_" + index;
        a = newcustomer.GetComponent<Animator>();
        a.SetFloat("Horizontal", -1);
        p = newcustomer.GetComponent<Patrol>();
        p.moving.x = -1;
        p.moving.y = 0;
        GameManager.addCustomerToLine(customer);
    }
}
