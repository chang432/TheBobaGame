using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceControl : MonoBehaviour
{

    public Transform iceObj;

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
        if (BobaMaking.currTeaType != "")
        {
            Debug.Log("U ALREADY PUT TEA U HOE");
            return;
        }

        if (BobaMaking.workingOrder.heatPercent != 0f)
        {
            Debug.Log("ITS HOT ALREADY U CANT ICE IT SMH");
            return;
        }

        switch (BobaMaking.currIceLevel)
        {
            case 1:
                Instantiate(iceObj, new Vector2(0, -1.15f), iceObj.rotation);
                BobaMaking.currIceLevel = 2;
                break;
            case 2:
                Instantiate(iceObj, new Vector2(0, -0.15f), iceObj.rotation);
                BobaMaking.currIceLevel = 3;
                break;
            case 3:
                Instantiate(iceObj, new Vector2(0, 0.75f), iceObj.rotation);
                BobaMaking.currIceLevel = 4;
                break;
            case 4:
                Instantiate(iceObj, new Vector2(0, 1.75f), iceObj.rotation);
                BobaMaking.currIceLevel = 5;
                break;
            default:
                Debug.Log("ITS FULL CANT PUT MORE ICE");
                return;
        }

        BobaMaking.workingOrder.icePercent += 25;
    }
}
