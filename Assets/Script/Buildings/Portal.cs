using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : ICreateResurces       // конвертирует валюту
{
    public override event BuildDelegate eventLevelUp;

    GameResources percentGrowth = new GameResources (0, goods: 0.25f, cash: 0.25f);          //процент увеличения ресурсов

    private float buyGoods;
    private float sellGoods;
    public float BuyGoods 
    { 
        get { return buyGoods; } 
        set 
        {
            buyGoods = value;
            if (buyGoods < 1) buyGoods = 1;
        }  
    }

    public float SellGoods
    {
        get { return sellGoods; }
        set
        {
            sellGoods = value;
            if (sellGoods > 1) buyGoods = 1;
        }
    }

    private const float upLevel = 0.01f;        //изменение разницы продажи и покупки товаров за 1 ур (в %)
    public Portal()
    {
        buyGoods = 1.5f;
        sellGoods = 0.5f;
        name = "Портал";
        lvl = 1;
        createResurces = percentGrowth;       
        UpPriceImprovement();
    }

    public override void LvlUp()
    {
        lvl++;
        createResurces += percentGrowth;       //в %        
        UpPriceImprovement();
        PriceControl();
        if (eventLevelUp != null) eventLevelUp(this);
    }

    private void PriceControl()
    {
        BuyGoods -= upLevel / 2;
        SellGoods += upLevel / 2;
    }
    public override GameResources NewResurse()
    {
        return createResurces;
    }
}
