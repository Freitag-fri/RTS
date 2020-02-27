using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpeed : IUnit
{
    public UnitSpeed(int SumUnit)
    {
        this.SumUnit = SumUnit;
        characteristicAtFirstLevel = new СharacteristicUnit (4, 3, 1);
    }
    public static int operator +(UnitSpeed c1, UnitSpeed c2)          //сумируем
    {
        return c1.SumUnit + c2.SumUnit;
    }
}
