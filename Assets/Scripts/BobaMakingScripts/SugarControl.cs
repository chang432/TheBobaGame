using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarControl : MonoBehaviour
{
    public Transform sugarObj;

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
        switch (BobaMaking.currSugarLevel)
        {
            case 1:
                Instantiate(sugarObj, new Vector2(0, -1.15f), sugarObj.rotation);
                BobaMaking.currSugarLevel = 2;
                break;
            case 2:
                Instantiate(sugarObj, new Vector2(0, -0.15f), sugarObj.rotation);
                BobaMaking.currSugarLevel = 3;
                break;
            case 3:
                Instantiate(sugarObj, new Vector2(0, 0.75f), sugarObj.rotation);
                BobaMaking.currSugarLevel = 4;
                break;
            case 4:
                Instantiate(sugarObj, new Vector2(0, 1.75f), sugarObj.rotation);
                BobaMaking.currSugarLevel = 5;
                break;
            default:
                Debug.Log("ITS FULL CANT PUT MORE SUGAR");
                return;
        }

        BobaMaking.workingOrder.sugarPercent += 25;
    }
}
