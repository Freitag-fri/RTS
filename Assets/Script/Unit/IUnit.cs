using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IUnit
{
    //int lvl;
    protected СharacteristicUnit characteristicAtFirstLevel;
    public int SumUnit { get; set; }
    public СharacteristicUnit Characteristic { get; set; }
    public void SetСharacteristicUnit(int lvl)
    {
        Characteristic = new СharacteristicUnit(0, 0.1f * lvl, 0.1f * lvl) + characteristicAtFirstLevel;
    }
    
}

public struct СharacteristicUnit
{
    float speed;
    float attack;
    float armor;

    public СharacteristicUnit(float speed, float attack, float armor)
    {
        this.speed = speed;
        this.attack = attack;
        this.armor = armor;
    }

    public static СharacteristicUnit operator +(СharacteristicUnit c1, СharacteristicUnit c2)          //сумируем
    {
        return new СharacteristicUnit { speed = c1.speed + c2.speed, attack = c1.attack + c2.attack, armor = c1.armor + c2.armor};
    }
}
