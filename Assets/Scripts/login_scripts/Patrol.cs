using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public bool isAtFront = false;
    public float speed;
    public Animator animator;
    public GameObject customer;
    public Vector3 moving = new Vector3(0.0f, 0.0f);
    public GM GameManager;

    /*IEnumerator waiter(float tempx, float tempy) {
        yield return new WaitForSeconds(4);
        //var isNotAlone = Physics2D.OverlapCircle(customer.transform.position, 1);
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(customer.transform.position, 40);
        print("obj name: "+customer.name);
        //for (var i = 0; i < hitColliders.Length; i++) {
        //    print(hitColliders[i]);
        //}
        if (hitColliders.Length == 1) {
            print("NO ONES AROUND");
            moving.x = tempx;
            moving.y = tempy;  
        } else {
            print("SOMETHINGS NEAR");
        }
    }*/

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

            /*if (moving.x == 0 && moving.y == 0) {
            } else {
                print("prefab trigger");
                //collide with person
                float tempx = moving.x;
                float tempy = moving.y;

                if (moving.x == 0 && moving.y != 0) {
                    animator.SetFloat("VerticalIdle", moving.y);
                } else if (moving.x != 0 && moving.y == 0) {
                    animator.SetFloat("HorizontalIdle", moving.x);
                }
                moving.x = 0;
                moving.y = 0;

                //while (moving.x == 0 && moving.y == 0) {
                StartCoroutine(waiter(tempx, tempy));
                
            }*/
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision!");
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(waiter(moving.x, moving.y));
        animator.SetFloat("Horizontal", moving.x);
        animator.SetFloat("Vertical", moving.y);
        transform.Translate(moving * speed * Time.deltaTime);


        // draws the raycasts for visual aspect
        float horizontalIdle = animator.GetFloat("HorizontalIdle");
        float verticalIdle = animator.GetFloat("VerticalIdle");
        Vector3 vect = Vector3.down*40;          // default is walking down or facing down
        if (moving.x < 0 || horizontalIdle < 0) {
            // moving left or facing left
            vect = Vector3.left*40;
        } else if (moving.x > 0 || horizontalIdle > 0) {
            // moving right or facing right
            vect = Vector3.right*40;
        } else if (moving.y > 0 || verticalIdle > 0) {
            // moving up or facing up
            vect = Vector3.up*40;
        } 
        Debug.DrawRay(customer.transform.position, vect, Color.green, Time.deltaTime, false);

    }
}
