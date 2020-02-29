using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{

    public static int money;

    public static string username;

    public void setMoney(int value)
    {
        money = value;
    }

    public int getMoney()
    {
        return money;
    }

    public string getUsername()
    {
        return username;
    }

    public void setUsername(string s)
    {
        username = s;
    }
}
