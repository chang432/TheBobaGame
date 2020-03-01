using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GM : MonoBehaviour
{
    // Start is called before the first frame update
    public static int money;

    public static Queue<GameObject> customers = new Queue<GameObject>();

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

    public void addCustomer(GameObject customer)
    {
        customers.Enqueue(customer);
    }





}

