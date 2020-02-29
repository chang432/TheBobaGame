using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SatisficationControl : MonoBehaviour
{
    Text text;

    public GameObject deleteIcon;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        InvokeRepeating("decreaseSatisfication", 1.0f, 1.0f);
    }

    void decreaseSatisfication()
    {
        BobaMaking.currOrderTimeTaken += 1;
        if (BobaMaking.currOrderTimeTaken >= 30 && BobaMaking.currSatisficationLevel > 0)
        {
            BobaMaking.currSatisficationLevel -= 1;
        }
        text.text = "SF: " + BobaMaking.currSatisficationLevel;
        if (BobaMaking.currSatisficationLevel == 0)
        {
            emptyCup();
        }
    }

    void emptyCup()
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

        BobaMaking.currOrderNum++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
