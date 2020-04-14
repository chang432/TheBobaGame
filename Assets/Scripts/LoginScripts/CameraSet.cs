using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSet : MonoBehaviour
{
    public GameObject shopBackground;
    // Start is called before the first frame update
    void Start()
    {
        float height = shopBackground.GetComponent<SpriteRenderer>().bounds.size.y;
        //print("height: " + height);
        Camera.main.orthographicSize = height / 2;
    }
}
