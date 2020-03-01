using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneBtn : MonoBehaviour
{
    Patrol p;
    public GameObject customer;
    int index = 0;
    private void OnMouseDown()
    {
        print("done btn pressed");
        index++;
        GameObject customer1 = GameObject.Find("customer_" + index);
        p = customer1.GetComponent<Patrol>();

        if (p.animator.GetFloat("VerticalIdle") != 0)
        {
            p.animator.SetFloat("VerticalIdle", 0);
            p.moving.x = -1;
            p.moving.y = 0;
        }
    }
}
