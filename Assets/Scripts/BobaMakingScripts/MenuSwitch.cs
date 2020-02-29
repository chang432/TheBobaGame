using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitch : MonoBehaviour
{

    public Transform teaTab;
    public Transform toppingsTab;


    // store all tea variables
    public GameObject teaBackground;
    public GameObject greenTea;
    //public GameObject blackTea;
    // add other tea

    // store all topping variables
    public GameObject toppingBackground;
    public GameObject boba;
    public GameObject pudding;
    // add other toppings

    // for now I'm just going to leave the locks stagnant across both pages because I don't care about them 

    // sets all parts of tea menu active
    void setTeaActive()
    {
        BobaMaking.currTab = "teaTab";
        teaBackground.SetActive(true);
        greenTea.SetActive(true);
        //blackTea.SetActive(true);

        toppingBackground.SetActive(false);
        boba.SetActive(false);
        pudding.SetActive(false);
        //Debug.Log("currTab: " + BobaMaking.currTab);
    }

    // sets all parts of toppings menu active
    void setToppingsActive()
    {
        BobaMaking.currTab = "toppingsTab";
        toppingBackground.SetActive(true);
        boba.SetActive(true);
        pudding.SetActive(true);

        teaBackground.SetActive(false);
        greenTea.SetActive(false);
        //blackTea.SetActive(false);
        //Debug.Log("currTab: " + BobaMaking.currTab);
    }

    // Start is called before the first frame update
    void Start()
    {
        setTeaActive();
        /*
        if (BobaMaking.currTab == "teaTab")
        {
            setTeaActive();
        }
        else if (BobaMaking.currTab == "toppingsTab")
        {
            setToppingsActive();
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (BobaMaking.currTab == "teaTab")
        {
            setTeaActive();
        }
        else if (BobaMaking.currTab == "toppingsTab")
        {
            setToppingsActive();
        }
        */
    }

    void OnMouseDown()
    {
        if (gameObject.name == "teas")
        {
            Debug.Log("pressed tea tab");
            setTeaActive();
        }
        else if (gameObject.name == "toppings")
        {
            setToppingsActive();
        }
    }
}
