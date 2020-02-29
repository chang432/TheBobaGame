using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    //public Transform groundDetection;
    public Animator animator;
    public Vector3 moving = new Vector3(0.0f, 0.0f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "OutsideCollider")
        {
            moving.x = 0;
            moving.y = 1;
        } else if (collision.gameObject.name == "ShopCounter")
        {
            moving.x = 0;
            moving.y = 0;
            animator.SetFloat("VerticalIdle", 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision!");
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", moving.x);
        animator.SetFloat("Vertical", moving.y);
        transform.Translate(moving * speed * Time.deltaTime);

        /*RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 3);
        if (groundInfo.collider == false)
        {
            moving.x = -moving.x;
        }*/

    }
}
