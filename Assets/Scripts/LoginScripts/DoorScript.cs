using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject frontWallClosed;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        frontWallClosed.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        frontWallClosed.SetActive(true);
    }
}
