using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheatDragControl : MonoBehaviour
{
    private bool isDragging;

    public void OnMouseDown()
    {
        Debug.Log("dragging");
        isDragging = true;
    }

    public void OnMouseUp()
    {
        Debug.Log("done");
        isDragging = false;
        if (gameObject.name == "draggable_pudding")
        {
            gameObject.transform.position = new Vector3(-0.697f, -4.313f, 0f);
        }
        else if (gameObject.name == "draggable_boba")
        {
            gameObject.transform.position = new Vector3(-2.046f, -4.412f, 0f);
        }
    }

    public void OnTriggerEnter2D(Collider2D cupCollider)
    {
        if (cupCollider.name == "empty cup")
        {
            Debug.Log("hit the cup");
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }
}
