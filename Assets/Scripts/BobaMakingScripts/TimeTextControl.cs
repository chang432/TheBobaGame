using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeTextControl : MonoBehaviour
{
    Text text;

    public GameObject timesupIcon;
    public GameObject deleteIcon;

    bool iconInstantiated = false;
    bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        int minutes = Mathf.FloorToInt(BobaMaking.currTimer / 60F);
        int seconds = Mathf.FloorToInt(BobaMaking.currTimer - minutes * 60);
        string timeFormat = string.Format("{0:0}:{1:00}", minutes, seconds);
        text.text = timeFormat;
    }

    // Update is called once per frame
    void Update()
    {
        BobaMaking.currTimer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(BobaMaking.currTimer / 60F);
        int seconds = Mathf.FloorToInt(BobaMaking.currTimer - minutes * 60);
        string timeFormat = string.Format("{0:0}:{1:00}", minutes, seconds);
        if (!done)
        {
            text.text = timeFormat;
        }

        if (BobaMaking.currTimer <= 0 && !iconInstantiated)
        {
            Debug.Log("STOP OUT OF TIME");
            text.text = "0:00";
            done = true;
            Vector3 newLocation = new Vector3(0, 0.3f, 0);
            GameObject clone = clone = (GameObject)Instantiate(timesupIcon, newLocation, Quaternion.identity);
            iconInstantiated = true;
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
}
