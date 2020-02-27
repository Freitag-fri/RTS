using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDef : IUnit
{
    public UnitDef(int SumUnit)
    {
        this.SumUnit = SumUnit;
        characteristicAtFirstLevel = new СharacteristicUnit(2, 2, 4);
    }

    public static int operator +(UnitDef unit_1, UnitDef unit_2)          //сумируем
    {
        return unit_1.SumUnit + unit_2.SumUnit;
    }
}
