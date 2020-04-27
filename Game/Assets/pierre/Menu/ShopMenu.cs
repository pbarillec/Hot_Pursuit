using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    public Text Wallet1;
    public Text Wallet2;
    public Text Wallet3;
    public Text Wallet4;
    public Text Wallet5;
    public Text CarSelected;
    public Text PriceSecond;
    public Text PriceThird;
    public int wallet = 0;
    public bool first = true;
    public bool second = false;
    public bool third = false;
    public int price_second = 500;
    public int price_third = 1000;
    public int select = 1;
    int temp_two = 0;
    int temp_three = 0;

    public GameObject second_buy;
    public GameObject second_v;
    public GameObject third_buy;
    public GameObject third_v;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Car", select);
        PlayerPrefs.SetInt("Pickup", 1);
        PlayerPrefs.SetInt("Sport", 0);
        PlayerPrefs.SetInt("Truck", 0);    }

    // Update is called once per frame
    void Update()
    {
        Wallet1.text = wallet.ToString();
        Wallet2.text = wallet.ToString();
        Wallet3.text = wallet.ToString();
        Wallet4.text = wallet.ToString();
        Wallet5.text = wallet.ToString();


        PriceSecond.text = "500";
        PriceThird.text = "1000";

        temp_two = PlayerPrefs.GetInt("Sport");
        if (temp_two == 1)
        {
            select = 2;
            second = true;
            second_buy.SetActive(true);
            second_v.SetActive(false);
        }

        temp_three = PlayerPrefs.GetInt("Truck");
        if (temp_three == 1)
        {
            select = 3;
            third = true;
            third_buy.SetActive(true);
            third_v.SetActive(false);
        }

        if (select == 1)
            CarSelected.text = "Vehicle selected: Pickup";
        else if (select == 2)
            CarSelected.text = "Vehicle selected: Sport Car";
        else
            CarSelected.text = "Vehicle selected: Truck";
        wallet = PlayerPrefs.GetInt("wallet");
    }

    int getWallet()
    {
        return (wallet);
    }

    void setWallet(int price)
    {
        wallet = wallet - price;
        PlayerPrefs.SetInt("wallet", wallet);
    }

    public void setSelect(int value)
    {
        select = value;
        PlayerPrefs.SetInt("Car", select);
    }

    public void buy_second()
    {
        if (wallet >= price_second)
        {
            setWallet(price_second);
            second = true;
            second_buy.SetActive(true);
            second_v.SetActive(false);
            PlayerPrefs.SetInt("Sport", 1);
        }
    }

    public void buy_third()
    {
        if (wallet >= price_third)
        {
            setWallet(price_third);
            third = true;
            third_buy.SetActive(true);
            third_v.SetActive(false);
            PlayerPrefs.SetInt("Truck", 1);
        }
    }
}

