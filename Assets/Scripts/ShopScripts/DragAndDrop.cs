using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject finalObj = null;

    [SerializeField]
    private LayerMask layerMask;

    private Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mouseRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D raycast = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, layerMask);

            if (raycast.collider == null && finalObj != null)
            {
                Debug.Log("place thing");
                Instantiate(finalObj, transform.position, Quaternion.identity);
            }
            else if (finalObj == null && raycast.collider != null)
            {
                finalObj = raycast.collider.gameObject;
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = finalObj.GetComponent<SpriteRenderer>().sprite;
            }
            else if (raycast.collider != null && finalObj != null)
            {
                if (raycast.collider.gameObject != finalObj)
                {
                    finalObj = raycast.collider.gameObject;
                    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = finalObj.GetComponent<SpriteRenderer>().sprite;
                }
            }

        }

    }
}
