using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingControl : MonoBehaviour
{
    // each layer needs to be independent from other things
    // like for example the 4th layer of boba should be able to be placed on top of the 3rd layer of jelly

    public Transform bobaLayer1;
    public Transform bobaLayer2;
    public Transform bobaLayer3;
    public Transform bobaLayer4;
    public Transform puddingLayer1;
    public Transform puddingLayer2;
    public Transform puddingLayer3;
    public Transform puddingLayer4;

    // add other toppings here

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
        if (BobaMaking.currTab != "toppingsTab")
        {
            return;
        }

        // also if we filled it up with tea u can't put toppings
        if (BobaMaking.currTeaType != "")
        {
            Debug.Log("U ALREADY PUT TEA U HOE");
            return;
        }

        if (gameObject.name == "boba")
        {
            switch (BobaMaking.currLayer)
            {
                case 1:
                    Instantiate(bobaLayer1, new Vector2(0, -1.3f), bobaLayer1.rotation);
                    BobaMaking.currLayer = 2;
                    break;

                case 2:
                    Instantiate(bobaLayer2, new Vector2(0, -.3f), bobaLayer2.rotation);
                    BobaMaking.currLayer = 3;
                    break;

                case 3:
                    Instantiate(bobaLayer3, new Vector2(0, .7f), bobaLayer3.rotation);
                    BobaMaking.currLayer = 4;
                    break;

                case 4:
                    Instantiate(bobaLayer4, new Vector2(0, 1.7f), bobaLayer4.rotation);
                    BobaMaking.currLayer = 5;
                    break;

                // can add more layers here easily

                default:
                    Debug.Log("ITS FUCKING FULL");
                    return;
            }

            BobaMaking.workingOrder.numBoba++;
        }

        if (gameObject.name == "pudding_icon")
        {
            switch (BobaMaking.currLayer)
            {
                case 1:
                    Instantiate(puddingLayer1, new Vector2(0, -1.3f), puddingLayer1.rotation);
                    BobaMaking.currLayer = 2;
                    break;

                case 2:
                    Instantiate(puddingLayer2, new Vector2(0, -.3f), puddingLayer2.rotation);
                    BobaMaking.currLayer = 3;
                    break;

                case 3:
                    Instantiate(puddingLayer3, new Vector2(0, .7f), puddingLayer3.rotation);
                    BobaMaking.currLayer = 4;
                    break;

                case 4:
                    Instantiate(puddingLayer4, new Vector2(0, 1.7f), puddingLayer4.rotation);
                    BobaMaking.currLayer = 5;
                    break;

                // can add more layers here easily

                default:
                    Debug.Log("ITS FUCKING FULL");
                    return;
            }

            BobaMaking.workingOrder.numJelly++;
        }
    }
}
