using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public delegate void AddArmyDelegate(int people);
public class Barrack : Building        //производство юнитов
{
    public override event BuildDelegate eventLevelUp;
    public event AddArmyDelegate eventAddArmy;

    public Squad unitSquad = new Squad(0, 0, 0);        //армия храниться здесь

    const int addLimetArmy = 100;
    public Barrack()
    {
        name = "Казарма";
        lvl = 1;
        UpPriceImprovement();
    }

    
    
    public override void LvlUp()
    {
        lvl++;
        UpPriceImprovement();
        eventLevelUp?.Invoke(this);
        eventAddArmy?.Invoke(addLimetArmy);
    }
}

public struct Squad
{
    public UnitSpeed unitSpeed;
    public UnitRush unitRush;
    public UnitDef unitDef;
    public Squad(int sumSpeedUnit, int sumSpeedRush, int sumSpeedDef)
    {
        unitSpeed = new UnitSpeed(sumSpeedUnit);
        unitRush = new UnitRush(sumSpeedRush);
        unitDef = new UnitDef(sumSpeedDef);
    }
    public static Squad operator +(Squad c1, Squad c2)          //сумируем
    {
        return new Squad ( c1.unitSpeed + c2.unitSpeed, c1.unitRush + c2.unitRush, c1.unitDef + c2.unitDef);
    }
}
