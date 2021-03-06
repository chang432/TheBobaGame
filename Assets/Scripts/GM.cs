﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GM : MonoBehaviour
{
    //static data structures and variables
    public static int money;

    public static string username;

    public static int xp;

    public static Queue<GameObject> customersInLine = new Queue<GameObject>();

    public static List<GameObject> customersInShop = new List<GameObject>();

    public static List<string> toppings = new List<string>();

    public static List<string> teas = new List<string>();



    //Use to load scenes
    public void LoadLoginScene()
    {
        SceneManager.LoadScene("LoginScene");
    }

    public void LoadShopScene()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void LoadBobaMakingScene()
    {
        SceneManager.LoadScene("BobaMakingScene");
    }







    //getters, setters, and contains funcions
    public void setUsername(string s)
    {
        username = s;
    }

    public string getUsername()
    {
        return username;
    }

    public void setXP(int x)
    {
        xp = x;
    }

    public int getXP()
    {
        return xp;
    }

    public void setMoney(int value)
    {
        money = value;
    }

    public int getMoney()
    {
        return money;
    }

    public void addCustomerToLine(GameObject customer)
    {
        customersInLine.Enqueue(customer);
        //Debug.Log(customers.Count);
    }

    public GameObject removeCustomerFromLine()
    {
        return customersInLine.Dequeue();
    }

    public bool toppingAvailable(string topping)
    {
        return toppings.Contains(topping);
    }

    public void addTopping(string t)
    {
        toppings.Add(t);
    }

    public void addCustomerToShop(GameObject c)
    {
        customersInShop.Add(c);
    }

    public GameObject removeCustomerFromShop(GameObject c)
    {
        customersInShop.Remove(c);
        return c;
    }

    public void addTea(string s)
    {
        teas.Add(s);
    }

    public string removeTea(string s)
    {
        teas.Remove(s);
        return s;
    }

    public bool teaAvailable(string s)
    {
        return teas.Contains(s);
    }

}

