using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneBtn : MonoBehaviour
{
    Patrol p;
    GameObject customer1;
    private void OnMouseDown()
    {
        customer1 = GameObject.Find("Customer1");
        p = customer1.GetComponent<Patrol>();

        if (p.animator.GetFloat("VerticalIdle") != 0)
        {
            p.animator.SetFloat("VerticalIdle", 0);
            p.moving.x = -1;
            p.moving.y = 0;
        }
    }
}
