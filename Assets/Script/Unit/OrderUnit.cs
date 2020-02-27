using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUnit : MonoBehaviour
{
    public GameObject menu;

    public InputField InputUnitSpeed;
    public InputField InputUnitRush;
    public InputField InputUnitDef;

    int sumSpeed;
    int sumRush;
    int sumDef;
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (InputUnitSpeed.text == "") sumSpeed = 0;
        else sumSpeed = int.Parse(InputUnitSpeed.text);

        if (InputUnitRush.text == "") sumRush = 0;
        else sumRush = int.Parse(InputUnitRush.text);

        if (InputUnitDef.text == "") sumDef = 0;
        else sumDef = int.Parse(InputUnitDef.text);

    }

    public void OpenMenu()
    {
        if (menu.activeSelf == true)
        {
            CloseMenu();
            return;
        }
        menu.SetActive(true);
    }
    public void CloseMenu()
    {
        InputUnitSpeed.text = string.Empty;
        InputUnitRush.text = string.Empty;
        InputUnitDef.text = string.Empty;
        menu.SetActive(false);
    }

    public void OrderUnit_()
    {
        
        int sum = sumSpeed + sumRush + sumDef;
        int priceUnit = sum * 10;
        Core pleyer = GetComponent<MainControl>().playerCore;

        if(pleyer.resources.Cash >= priceUnit && pleyer.resources.Goods >= priceUnit && pleyer.resources.People >= sum && pleyer.resources.Army + sum <= pleyer.armyLimit)
        {
            pleyer.resources.Cash -= priceUnit;
            pleyer.resources.Goods -= priceUnit;
            pleyer.resources.People -= sum;
            pleyer.resources.Army += sum;
            pleyer.barrack.unitSquad += new Squad(sumSpeed, sumRush, sumDef);
        }   


        CloseMenu();
    }

}
