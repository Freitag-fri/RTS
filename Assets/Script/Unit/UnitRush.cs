using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRush : IUnit
{
    public UnitRush(int SumUnit)
    {
        this.SumUnit = SumUnit;
        characteristicAtFirstLevel = new СharacteristicUnit(2, 5, 1);
    }
    public static int operator +(UnitRush c1, UnitRush c2)          //сумируем
    {
        return c1.SumUnit + c2.SumUnit;
    }
}
