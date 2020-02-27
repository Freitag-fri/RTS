using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BuildDelegate(Building build);

public abstract class  Building 
{
    protected int numberBuildInInformation;
    protected int lvl;
    protected string name;
    public int Lvl { get { return lvl; } }
    public string Name { get { return name; } }
    public int NumberBuildInInformation { get { return numberBuildInInformation; } set { numberBuildInInformation = value; } }
    public GameResources priceImprovement;
    public GameResources PriceImprovement { get { return priceImprovement; } set { UpPriceImprovement(); } }
    protected void UpPriceImprovement()
    {
        priceImprovement.Goods = 100 * Lvl / 0.985f;
        priceImprovement.Cash = 100 * Lvl / 0.985f;
    }

    public abstract void LvlUp();
    public virtual event BuildDelegate eventLevelUp;
    
}

public abstract class ICreateResurces : Building
{
    public GameResources createResurces;
    public abstract GameResources NewResurse();
}
