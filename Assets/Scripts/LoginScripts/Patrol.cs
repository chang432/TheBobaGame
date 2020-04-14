using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GM GameManager;
    public bool isAtFront = false;
    public float speed;
    public Animator animator;
    public GameObject customer;
    public Rigidbody2D customerRb;
    public Vector2 moving = new Vector2(0.0f, 0.0f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("TRIGGERED!");
        if (collision.gameObject.name == "OutsideCollider")
        {
            moving.x = 0;
            moving.y = 1;
        } else if (collision.gameObject.name == "ShopCounter")
        {
            isAtFront = true; 
            moving.x = 0;
            moving.y = 0;
            animator.SetFloat("VerticalIdle", 1);
        } else {
            if (moving.x == 0 && moving.y != 0) {
                animator.SetFloat("VerticalIdle", moving.y);
            } else if (moving.x != 0 && moving.y == 0) {
                animator.SetFloat("HorizontalIdle", moving.x);
            }
            moving.x = 0;
            moving.y = 0;
        }
    }

    private void FixedUpdate()
    {
        float horizontalIdle = animator.GetFloat("HorizontalIdle");
        float verticalIdle = animator.GetFloat("VerticalIdle");

        Physics2D.queriesStartInColliders = false;          // ignores hit on itself
        RaycastHit2D hit = Physics2D.Raycast(customer.transform.position, Vector3.up, 50);
        if (hit.collider == null && (horizontalIdle != 0 || verticalIdle != 0))
        {
            //Debug.Log(customer.transform.name + " HIT " + hit.transform.gameObject.name);
            moving.x = horizontalIdle;
            moving.y = verticalIdle;
            animator.SetFloat("HorizontalIdle", 0);
            animator.SetFloat("VerticalIdle", 0);
        }

        animator.SetFloat("Horizontal", moving.x);
        animator.SetFloat("Vertical", moving.y);
        customerRb.MovePosition((Vector2)transform.position + (moving * speed * Time.deltaTime));

        // draws the raycasts for visual aspect
        Vector3 vect = Vector3.down* 50;          // default is walking down or facing down
        if (moving.x < 0 || horizontalIdle < 0) {
            // moving left or facing left
            vect = Vector3.left*50;
        } else if (moving.x > 0 || horizontalIdle > 0) {
            // moving right or facing right
            vect = Vector3.right*50;
        } else if (moving.y > 0 || verticalIdle > 0) {
            // moving up or facing up
            vect = Vector3.up*50;
        }
        Debug.DrawRay(customer.transform.position, vect, Color.green, Time.deltaTime, false);
    }
}
