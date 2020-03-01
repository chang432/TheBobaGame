using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneBtn : MonoBehaviour
{
    Patrol p;
    public GameObject customer;
    private void OnMouseDown()
    {
        print("done btn pressed");
        GameObject customer1 = GameObject.Find("Customer1");
        p = customer.GetComponent<Patrol>();

        if (p.animator.GetFloat("VerticalIdle") != 0)
        {
            p.animator.SetFloat("VerticalIdle", 0);
            p.moving.x = -1;
            p.moving.y = 0;
        }
    }
}
