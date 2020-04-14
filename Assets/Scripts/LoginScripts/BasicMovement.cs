using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;

    // Update is called once per frame 
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

        Vector3 newPos = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        newPos = newPos * 3 * Time.deltaTime;
        rb.MovePosition(rb.transform.position + newPos);
        /*Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * 3 * Time.deltaTime;

        Vector3 vertical = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);
        transform.position = transform.position + vertical * 3 * Time.deltaTime;*/
    }
}
