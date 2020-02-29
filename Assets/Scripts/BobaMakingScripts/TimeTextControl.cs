using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeTextControl : MonoBehaviour
{
    Text text;
    public GameObject timesupIcon;
    bool iconInstantiated = false;

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
        text.text = timeFormat;

        if (BobaMaking.currTimer <= 0 && !iconInstantiated)
        {
            Debug.Log("STOP OUT OF TIME");
            Vector3 newLocation = new Vector3(0, 0.3f, 0);
            GameObject clone = clone = (GameObject)Instantiate(timesupIcon, newLocation, Quaternion.identity);
            iconInstantiated = true;
        }
    }
}
