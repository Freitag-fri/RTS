using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkShop : ICreateResurces       // цех — позволяет производить товары;
{
    public override event BuildDelegate eventLevelUp;
    GameResources percentGrowth = new GameResources(0, goods: 1.75f, 0);

    public WorkShop()
    {
        name = "Цех";
        createResurces = percentGrowth;
        lvl = 1;
        UpPriceImprovement();
    }

    public override void LvlUp()
    {
        lvl++;
        createResurces += percentGrowth;
        if (eventLevelUp != null) eventLevelUp(this);
        UpPriceImprovement();
    }

    public override GameResources NewResurse()
    {
        return createResurces;                                       
    }
}
