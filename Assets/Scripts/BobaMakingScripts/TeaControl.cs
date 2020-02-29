using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaControl : MonoBehaviour
{

    public Transform greenTea;
    public Transform blackTea;
    // add other teas here

    public Transform fullGreenTea;
    public Transform greenTeaFill;
    public Transform fullBlackTea;
    public Transform blackTeaFill;

    public bool isGreen = false;
    public bool isBlack = false;
    //public bool isFull = false;

    // Start is called before the first frame update
    void Start()
    {
        var newGreenScale = this.greenTeaFill.localScale;
        newGreenScale.y = 0;
        this.greenTeaFill.localScale = newGreenScale;

        var newBlackScale = this.blackTeaFill.localScale;
        newBlackScale.y = 0;
        this.blackTeaFill.localScale = newBlackScale;
    }

    void fillGreen()
    {
        if (BobaMaking.currFillPercent <= 1f)
        {
            BobaMaking.currFillPercent = BobaMaking.currFillPercent + 0.005f;
            var fillAmount = Mathf.Clamp01(BobaMaking.currFillPercent);

            var newScale = this.greenTeaFill.localScale;
            newScale.y = this.fullGreenTea.localScale.y * fillAmount;
            this.greenTeaFill.localScale = newScale;
        }
        else
        {
            if (!BobaMaking.isFull)
            {
                Debug.Log("ITS FUCKING FULL");
                BobaMaking.isFull = true;
            }
        }
    }

    void fillBlack()
    {
        if (BobaMaking.currFillPercent <= 1f)
        {
            BobaMaking.currFillPercent = BobaMaking.currFillPercent + 0.005f;
            var fillAmount = Mathf.Clamp01(BobaMaking.currFillPercent);

            var newScale = this.blackTeaFill.localScale;
            newScale.y = this.fullBlackTea.localScale.y * fillAmount;
            this.blackTeaFill.localScale = newScale;
        }
        else
        {
            if (!BobaMaking.isFull)
            {
                Debug.Log("ITS FUCKING FULL");
                BobaMaking.isFull = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGreen)
        {
            if (BobaMaking.currTeaType == "" || BobaMaking.currTeaType == "green")
            {
                BobaMaking.currTeaType = "green";
                fillGreen();
            }
            else
            {
                Debug.Log("OTHER TEA ALREADY IN");
            }
        }
        else if (isBlack)
        {
            if (BobaMaking.currTeaType == "" || BobaMaking.currTeaType == "black")
            {
                BobaMaking.currTeaType = "black";
                fillBlack();
            }
            else
            {
                Debug.Log("OTHER TEA ALREADY IN");
            }
        }

        if (BobaMaking.delete)
        {
            setEmpty();
        }
    }

    public void setEmpty()
    {
        if (BobaMaking.currTeaType == "green")
        {
            var newGreenScale = this.greenTeaFill.localScale;
            newGreenScale.y = 0;
            this.greenTeaFill.localScale = newGreenScale;
        }
        else if (BobaMaking.currTeaType == "black")
        {
            var newBlackScale = this.blackTeaFill.localScale;
            newBlackScale.y = 0;
            this.blackTeaFill.localScale = newBlackScale;
        }

        BobaMaking.delete = false;
        BobaMaking.currTeaType = "";
        BobaMaking.currFillPercent = 0f;
    }


    void OnMouseDown()
    {
        //Debug.Log("Mouse Down");
        //Debug.Log("isGreen: " + isGreen + "  isBlack: " + isBlack);

        if (BobaMaking.currTab != "teaTab")
        {
            return;
        }

        if (gameObject.name == "green tea")
        {
            //Debug.Log("green tea pressed");
            isGreen = true;
            BobaMaking.workingOrder.teaType = "Green";
        }
        else if (gameObject.name == "black tea")
        {
            //Debug.Log("black tea pressed");
            isBlack = true;
            BobaMaking.workingOrder.teaType = "Black";
        }
    }

    void OnMouseUp()
    {
        //Debug.Log("isGreen: " + isGreen + "  isBlack: " + isBlack);
        //Debug.Log("Mouse Up");
        isGreen = false;
        isBlack = false;
    }
}
