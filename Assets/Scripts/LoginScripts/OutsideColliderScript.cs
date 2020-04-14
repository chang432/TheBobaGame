using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideColliderScript : MonoBehaviour
{

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawCube(transform.position, new Vector2(50, 50));
        Gizmos.DrawSphere(transform.position, 10);
    }
}
