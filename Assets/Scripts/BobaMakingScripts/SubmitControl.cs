using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SubmitControl : MonoBehaviour
{

    public GameObject incorrectIcon;
    public GameObject correctIcon;
    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (clicked == 1 && Time.time - clicktime > 1)
        {
            clicked = 0;
            Debug.Log("reset clicks");
        }
    }

    bool checkOrderCorrect()
    {
        //teaType
        //icePercent
        //heatLevel
        //sugarPercent
        //numBoba
        //numJelly
        bool isRight = true;

        if (BobaMaking.customerOrder.teaType != BobaMaking.workingOrder.teaType)
        {
            Debug.Log("WRONG TEA U FUCK: " + BobaMaking.workingOrder.teaType);
            isRight = false;
        }

        if (BobaMaking.currFillPercent < 1)
        {
            Debug.Log("BITCH U DIDNT FILL MY DRINK ALL THE WAY: " + BobaMaking.currFillPercent);
            isRight = false;
        }

        if (BobaMaking.customerOrder.numBoba != BobaMaking.workingOrder.numBoba)
        {
            Debug.Log("WRONG BOBA AMOUNT R U DUMB: " + BobaMaking.workingOrder.numBoba);
            isRight = false;
        }

        if (BobaMaking.customerOrder.numJelly != BobaMaking.workingOrder.numJelly)
        {
            Debug.Log("WRONG JELLY AMOUNT R U DUMB: " + BobaMaking.workingOrder.numJelly);
            isRight = false;
        }

        if (BobaMaking.customerOrder.icePercent != BobaMaking.workingOrder.icePercent)
        {
            Debug.Log("ICE WRONG CMON BRO: " + BobaMaking.workingOrder.icePercent);
            isRight = false;
        }

        if (BobaMaking.customerOrder.heatPercent == 1f && BobaMaking.workingOrder.heatPercent < 0.75f)
        {
            Debug.Log("U DID HEAT WRONG...ITS NOT HOT ENOUGH: " + BobaMaking.workingOrder.heatPercent);
            isRight = false;
        }
        else if (BobaMaking.customerOrder.heatPercent == 0f && BobaMaking.workingOrder.heatPercent > 0f)
        {
            Debug.Log("U DID HEAT WRONG...ITS NOT SUPPOSED TO BE HOT BUT U DID: " + BobaMaking.workingOrder.heatPercent);
            isRight = false;
        }

        if (BobaMaking.customerOrder.sugarPercent != BobaMaking.workingOrder.sugarPercent)
        {
            Debug.Log("SUGAR IS WRONG GET UR SHIT TOGETHER: " + BobaMaking.workingOrder.sugarPercent);
            isRight = false;
        }

        return isRight;
    }

    void RunSubmit()
    {
        GameObject clone;

        if (checkOrderCorrect())
        {
            Vector3 newLocation = new Vector3(0, 0.3f, 0);
            clone = (GameObject)Instantiate(correctIcon, newLocation, Quaternion.identity);

            BobaMaking.currMoney = BobaMaking.currMoney + 20;
            BobaMaking.currExp = BobaMaking.currExp + 5;
            Debug.Log("Got it right!");
            BobaMaking.isSolved = true;
            //Debug.Log("it's set: " + BobaMaking.isSolved);
        }
        else
        {
            Vector3 newLocation = new Vector3(0, 0.3f, 0);
            clone = (GameObject)Instantiate(incorrectIcon, newLocation, Quaternion.identity);

            BobaMaking.currMoney = BobaMaking.currMoney - 10;
        }

        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");

        foreach (GameObject cloneObj in clones)
        {
            Destroy(cloneObj);
        }
        BobaMaking.delete = true;

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

        BobaMaking.workingOrder = new BobaMaking.Order("");
        if (BobaMaking.currMoney < 0)
        {
            Debug.Log("U SUCK");
        }
        Destroy(clone, 1.0f);
    }

    void OnMouseDown()
    {
        Debug.Log(clicked + " : clicks");
        clicked++;
        Debug.Log(clicked + " : clicks");
        if (clicked == 1) clicktime = Time.time;
        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            Debug.Log("double clicked");
            RunSubmit();
        }
        else if (clicked >= 2 || Time.time - clicktime > 1) clicked = 0;
    }
}
