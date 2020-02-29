using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatControl : MonoBehaviour
{

    public GameObject flame1;
    public GameObject flame2;
    public GameObject flame3;

    public GameObject deleteIcon;

    public GameObject progressBar;
    public GameObject acceptedRange;
    public Transform fullBar;
    public Transform barFill;

    bool mousePressed = false;
    bool flameInProgress = false;
    bool startedFlame = false;

    // Start is called before the first frame update
    void Start()
    {
        var newProgressScale = this.barFill.localScale;
        newProgressScale.y = 0;
        this.barFill.localScale = newProgressScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (mousePressed)
        {
            flame1.SetActive(true);
            /*
            if (!startedFlame)
            {
                startedFlame = true;
                Vector3 newLocation = new Vector3(0.02f, -2.14f, 0);
                cloneFlame1 = (GameObject)Instantiate(flame1, newLocation, Quaternion.identity);
            }
            */
            //Debug.Log("heat percent: " + BobaMaking.currHeatPercent);
            fillProgressBar();
            if (!flameInProgress)
            {
                flameAnimate();
            }
        }
    }

    void initiateFlame2()
    {
        flame2.SetActive(true);
    }

    void initiateFlame3()
    {
        flame3.SetActive(true);
    }

    void destroyFlame2()
    {
        flame2.SetActive(false);
    }

    void destroyFlame3()
    {
        flame3.SetActive(false);
    }

    void flameAnimate()
    {
        flameInProgress = true;
        //Debug.Log("flamingggg");
        Invoke("initiateFlame2", 0.3f);
        Invoke("initiateFlame3", 0.6f);
        Invoke("destroyFlame3", 0.9f);
        Invoke("destroyFlame2", 1.2f);
        Invoke("initiateFlame2", 1.5f);
        Invoke("initiateFlame3", 1.8f);
        Invoke("destroyFlame3", 2.1f);
        Invoke("destroyFlame2", 2.4f);
        Invoke("initiateFlame2", 2.7f);
        Invoke("initiateFlame3", 3.0f);
        Invoke("destroyFlame3", 3.3f);
        Invoke("destroyFlame2", 3.6f);

        //flameInProgress = false;
        //Debug.Log("flame: " + flameInProgress);


    }

    void fillProgressBar()
    {
        if (BobaMaking.currHeatPercent <= 1f)
        {
            BobaMaking.currHeatPercent = BobaMaking.currHeatPercent + 0.005f;
            var fillAmount = Mathf.Clamp01(BobaMaking.currHeatPercent);

            var newScale = this.barFill.localScale;
            newScale.y = this.fullBar.localScale.y * fillAmount;
            this.barFill.localScale = newScale;

        }
        else
        {
            if (!BobaMaking.isBurned)
            {
                Debug.Log("ITS BURNED");
                BobaMaking.isBurned = true;
                // empty the cup
                emptyCup();
            }
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
    }

    void OnMouseDown()
    {
        // check if ice
        if (BobaMaking.currIceLevel != 1)
        {
            Debug.Log("THERES ICE BITCH U CANT HOT");
            return;
        }

        // check if tea
        /*
        if (BobaMaking.currTeaType == "")
        {
            Debug.Log("NO TEA CANT HOT");
            return;
        }
        */

        // instantiate the progress bar
        //Instantiate(progressBar, new Vector2(2.46f, 1.65f), Quaternion.identity);
        //Instantiate(acceptedRange, new Vector2(2.46f, 2.39f), Quaternion.identity);
        progressBar.SetActive(true);
        acceptedRange.SetActive(true);

        Debug.Log("DRINK IS HOT NOW");
        mousePressed = true;
    }

    void OnMouseUp()
    {
        Debug.Log("GOT HERE");
        mousePressed = false;
        //Destroy(progressBar);
        //Destroy(acceptedRange);
        progressBar.SetActive(false);
        acceptedRange.SetActive(false);
        flame1.SetActive(false);
        flame2.SetActive(false);
        flame3.SetActive(false);
        
        var newFillScale = this.barFill.localScale;
        newFillScale.y = 0;
        this.barFill.localScale = newFillScale;
        CancelInvoke();
        flame1.SetActive(false);
        flame2.SetActive(false);
        flame3.SetActive(false);
        flameInProgress = false;
    }
}
