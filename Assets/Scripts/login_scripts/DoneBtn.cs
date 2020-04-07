using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneBtn : MonoBehaviour
{
    [SerializeField]
    public GM GameManager;

    Patrol p;
    private void OnMouseDown()
    {
        Debug.Log("done btn pressed");

        for (int playerNum=0;playerNum<GM.customersInLine.Count;playerNum++) {
            //Debug.Log("Customer_" + playerNum);
            GameObject customer = GameObject.Find("Customer_" + playerNum);
            p = customer.GetComponent<Patrol>();

            Physics2D.queriesStartInColliders = false;          // ignores hit on itself
            RaycastHit2D hit = Physics2D.Raycast(customer.transform.position, Vector3.up, 40);
            if (hit.collider != null) Debug.Log(customer.transform.name +" HIT "+hit.transform.gameObject.name);
            
            if (p.isAtFront) {
                p.animator.SetFloat("VerticalIdle", -1);
                p.moving.x = -1;
                p.moving.y = 0;
            } else if (hit.collider == null) {
                p.animator.SetFloat("VerticalIdle", 0);
                p.moving.x = 0;
                p.moving.y = 1;
            }
        }
        

    }
}
