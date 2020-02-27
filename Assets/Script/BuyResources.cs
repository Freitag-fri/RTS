using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyResources : MonoBehaviour
{
    bool status;
    public Text textAfter;
    public Text textBefore;
    public GameObject panel;
    public InputField inputField;
    float koef;
    float needValue;

    void Start()
    {
        //InputField.text = "0";
        panel.SetActive(false);
    }

    void Update()
    {
        if  (inputField.text == "") needValue = 0;
        else needValue = float.Parse(inputField.text) * koef;

        SetText();
    }    
    public void OpenMenuBuyGoods()
    {
        status = false;
        panel.SetActive(true);
        koef = GetComponent<MainControl>().playerCore.portal.BuyGoods;
        SetText();
    }

    public void OpenMenuBuyCash()
    {
        status = true;
        panel.SetActive(true);
        koef = 1 / GetComponent<MainControl>().playerCore.portal.SellGoods;
        SetText();
    }

    void SetText()
    {
        if (status)
        {
            textBefore.text = "Купить кредитов";
            textAfter.text = " * " + koef.ToString() + " за " + needValue.ToString()  + " Товаров";
        }
        else
        {
            textBefore.text = "Купить товаров";
            textAfter.text = " * " + koef.ToString() + " за " + needValue.ToString() + " Кредитов";
        }
    }

    public void Buy()
    {
        if (inputField.text == "")
        {
            panel.SetActive(false);
            return;
        }

        if (status && GetComponent<MainControl>().playerCore.resources.Goods >= needValue)
        {
            GetComponent<MainControl>().playerCore.resources.Goods -= needValue;
            GetComponent<MainControl>().playerCore.resources.Cash += float.Parse(inputField.text);
        }

        else if(!status && GetComponent<MainControl>().playerCore.resources.Cash >= needValue)
        {
            GetComponent<MainControl>().playerCore.resources.Cash -= needValue;
            GetComponent<MainControl>().playerCore.resources.Goods += float.Parse(inputField.text);
        }

        CloseMenu();
    }

    public void CloseMenu()
    {
        inputField.text = string.Empty;
        panel.SetActive(false);
    }
}
