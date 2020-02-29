using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragController : MonoBehaviour
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
        Destroy(gameObject);
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
