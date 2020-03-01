using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneBtn : MonoBehaviour
{
    [SerializeField]
    public GM GameManager;

    Patrol p;
    int index = 0;
    private void OnMouseDown()
    {
        print("done btn pressed");
        GameObject customer = GameObject.Find("Customer_" + index);
        index++;
        p = customer.GetComponent<Patrol>();

        if (p.animator.GetFloat("VerticalIdle") != 0)
        {
            p.animator.SetFloat("VerticalIdle", 0);
            p.moving.x = -1;
            p.moving.y = 0;
        }

        //GameManager.removeCustomer();

    }
}
