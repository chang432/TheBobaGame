using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GM : MonoBehaviour
{
    // Start is called before the first frame update
    public static int money;

    public static Queue<GameObject> customersInLine = new Queue<GameObject>();

    public static List<GameObject> customersInShop = new List<GameObject>();

    public static List<string> toppings = new List<string>();

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




}

