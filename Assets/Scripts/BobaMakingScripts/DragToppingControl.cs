using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToppingControl : MonoBehaviour
{

    public GameObject bobaDragIcon;
    public GameObject puddingDragIcon;
    public GameObject collide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("clicked object");

        Debug.Log("name: " + gameObject.name);

        if (gameObject.name == "boba")
        {
            //GameObject toDrag = Instantiate(bobaDragIcon, new Vector2(-2.046f, -4.412f), Quaternion.identity);
        }

        else if (gameObject.name == "pudding_icon")
        {
            //GameObject puddingDrag = Instantiate(puddingDragIcon, new Vector2(-0.697f, -4.313f), Quaternion.identity);
        }
    }
}
