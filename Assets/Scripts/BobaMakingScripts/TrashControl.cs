using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TrashControl : MonoBehaviour
{
    public GameObject deleteIcon;

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
        Vector3 newLocation = new Vector3(0, 0.3f, 0);
        GameObject clone = (GameObject)Instantiate(deleteIcon, newLocation, Quaternion.identity);

        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");

        foreach (GameObject cloneObj in clones)
        {
            Destroy(cloneObj);
        }

        BobaMaking.currIceLevel = 1;
        BobaMaking.currSugarLevel = 1;
        BobaMaking.currLayer = 1;
        BobaMaking.isFull = false;
        BobaMaking.currSatisficationLevel = 100;
        BobaMaking.currOrderTimeTaken = 0;
        BobaMaking.flame1 = false;
        BobaMaking.flame2 = false;
        BobaMaking.flame3 = false;
        BobaMaking.currHeatPercent = 0f;

        BobaMaking.currMoney = BobaMaking.currMoney - 10;
        BobaMaking.workingOrder = new BobaMaking.Order("");
        if (BobaMaking.currMoney < 0)
        {
            Debug.Log("U SUCK");
        }
        BobaMaking.delete = true;

        Destroy(clone, 1.0f);
    }

    // delete when collide
    /*
    public void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        BobaMaking.currLayer = BobaMaking.currLayer - 1;
    }
    */
}
