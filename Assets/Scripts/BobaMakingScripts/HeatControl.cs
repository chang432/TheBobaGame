using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatControl : MonoBehaviour
{

    public GameObject flame1;
    public GameObject flame2;
    public GameObject flame3;

    public GameObject progressBar;
    public GameObject acceptedRange;
    public Transform fullBar;
    public Transform barFill;

    bool mousePressed = false;

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
            //Debug.Log("heat percent: " + BobaMaking.currHeatPercent);
            fillProgressBar();
        }
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

            if (BobaMaking.currHeatPercent >= 0.25f && !BobaMaking.flame1)
            {
                //Instantiate(flame1, new Vector2(0.02f, -2.14f), Quaternion.identity);
                flame1.SetActive(true);
                //Destroy(flame1clone, 0.5f);
                BobaMaking.flame1 = true;
            }
            else if (BobaMaking.currHeatPercent >= 0.50f && !BobaMaking.flame2)
            {
                //GameObject flame2clone = Instantiate(flame2, new Vector2(0.02f, -2.14f), Quaternion.identity);
                //Destroy(flame2clone, 0.5f);
                flame2.SetActive(true);
                flame1.SetActive(false);
                BobaMaking.flame2 = true;
            }
            else if (BobaMaking.currHeatPercent >= 0.75f && !BobaMaking.flame3)
            {
                //GameObject flame3clone = Instantiate(flame3, new Vector2(0.02f, -2.14f), Quaternion.identity);
                //Destroy(flame3clone, 0.5f);
                flame3.SetActive(true);
                flame2.SetActive(false);
                BobaMaking.flame3 = true;
            }
        }
        else
        {
            if (!BobaMaking.isBurned)
            {
                Debug.Log("ITS BURNED");
                BobaMaking.isBurned = true;
            }
        }
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
    }
}
