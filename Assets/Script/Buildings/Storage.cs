using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void AddPeopleDelegate(int people);
public class Storage : ICreateResurces        //жилой модуль
{
    public override event BuildDelegate eventLevelUp;
    public event AddPeopleDelegate eventAddPeople;

    GameResources percentGrowth = new GameResources(people: 5, 0, 0, 0);

    private const int addLimetPeople = 200;
    public Storage()
    {
        name = "Жилой модуль";
        lvl = 1;
        createResurces = percentGrowth;
        UpPriceImprovement();
    }

    public override void LvlUp()
    {
        lvl++;
        createResurces += percentGrowth;
        UpPriceImprovement();
        eventLevelUp?.Invoke(this);
        eventAddPeople?.Invoke(addLimetPeople);
    }
    public override GameResources NewResurse()
    {
        return createResurces;                    
    }

}
