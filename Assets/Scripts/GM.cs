using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    // Start is called before the first frame update
    public static int money;

    public void setMoney(int value)
    {
        money = value;
    }

    public int getMoney()
    {
        return money;
    }
}
