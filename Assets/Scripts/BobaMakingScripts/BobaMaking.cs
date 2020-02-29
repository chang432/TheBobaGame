using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BobaMaking : MonoBehaviour
{
    // use for layer control
    public static int currLayer = 1;
    public static GameObject layer1;

    // these would be taken as inputs when we call the function
    public static int currMoney = 100;
    public static string currOrder = "Green tea, 50% ice, 25% sugar, 2 boba, 1 pudding";
    public static float currTimer = 300;
    public static int currExp = 50;

    // satisfication
    public static int currSatisficationLevel = 100;
    public static int currOrderTimeTaken = 0;

    // just for testing
    public static string[] orders = { "Green tea, 50% ice, 25% sugar, 2 boba, 1 pudding", "Green tea, 50% sugar, 3 boba, add heat", "Green tea, 75% ice, 1 pudding",
    "Green tea, 25% ice, 25% sugar, 2 boba, 2 puddding", "Green tea, 25% ice, 100% sugar, 1 boba, 1 pudding", "Green tea, 100% ice, 25% sugar, 1 boba",
    "Green tea, 2 boba, add heat", "Green tea, 100% sugar, 1 boba, 1 pudding, add heat"};
    public static bool isSolved = false;
    public static int currOrderNum = 0;

    // use for validation of order
    public static Order customerOrder;
    public static Order workingOrder = new Order("");

    // use for menu switch - start on tea when we open? (kinda think it might make more sense to start on toppings)
    public static string currTab = "teaTab";

    // use to keep track of tea
    public static string currTeaType = "";
    public static string prevTeaType = "";
    public static float currFillPercent = 0f;
    public static bool isFull = false;

    // use for ice
    public static int currIceLevel = 1;

    // use for sugar
    public static int currSugarLevel = 1;

    // use for heat
    public static float currHeatPercent = 0f;
    public static bool isBurned = false;
    public static bool flame1 = false;
    public static bool flame2 = false;
    public static bool flame3 = false;

    public static bool delete = false;

    // definition of Order - add to this as needed depending on toppings
    public struct Order
    {
        public string teaType;
        public int icePercent;
        public float heatPercent;
        public int sugarPercent;
        public int numBoba;
        public int numJelly;

        // constructor either creates empty if string is empty or parses information to store info about the customer's order
        public Order(string currOrder)
        {
            if (currOrder == "")
            {
                teaType = "";
                icePercent = 0;
                heatPercent = 0f;
                sugarPercent = 0;
                numBoba = 0;
                numJelly = 0;
                return;
            }

            string[] orderComponents = currOrder.Split(',');

            // there will always be tea so it will always be index 0
            teaType = orderComponents[0].Split(' ')[0];
            //Debug.Log("teaType: " + teaType);

            // everything else might be in different order
            // iterate through each component and do based on what is the second word
            // THIS ASSUMES EVERY ORDER COMPONENT IS ONLY ONE WORD

            icePercent = 0;
            heatPercent = 0f;
            sugarPercent = 0;
            numBoba = 0;
            numJelly = 0;

            for (int i = 1; i < orderComponents.Length; i++)
            {
                switch (orderComponents[i].Split(' ')[2])
                {
                    case "ice":
                        int icePercentLocation = orderComponents[i].Split(' ')[1].IndexOf("%", StringComparison.Ordinal);
                        icePercent = Int32.Parse(orderComponents[i].Split(' ')[1].Substring(0, icePercentLocation));

                        //Debug.Log("icePercent: " + icePercent);
                        break;

                    case "heat":
                        string level = orderComponents[i].Split(' ')[1];
                        /*
                        switch (level)
                        {
                            case "low":
                                heatLevel = 1;
                                break;

                            case "medium":
                                heatLevel = 2;
                                break;

                            case "high":
                                heatLevel = 3;
                                break;

                            default:
                                heatLevel = 0;
                                break;
                        }
                        */
                        heatPercent = 1f;

                        //Debug.Log("heatLevel: " + heatLevel);
                        break;

                    case "sugar":
                        int sugarPercentLocation = orderComponents[i].Split(' ')[1].IndexOf("%", StringComparison.Ordinal);
                        sugarPercent = Int32.Parse(orderComponents[i].Split(' ')[1].Substring(0, sugarPercentLocation));

                        //Debug.Log("sugarPercent: " + sugarPercent);
                        break;

                    case "boba":

                        numBoba = Int32.Parse(orderComponents[i].Split(' ')[1]);

                        //Debug.Log("numBoba: " + numBoba);
                        break;

                    case "jelly":
                        numJelly = Int32.Parse(orderComponents[i].Split(' ')[1]);

                        //Debug.Log("numJelly: " + numJelly);
                        break;

                    default:
                        break;
                }
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //customerOrder = new Order(currOrder);
        customerOrder = new Order(orders[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSolved)
        {
            currOrderNum++;
            if (currOrderNum == 8)
            {
                currOrderNum = 0;
            }

            customerOrder = new Order(orders[currOrderNum]);
            isSolved = false;
        }
    }
}
