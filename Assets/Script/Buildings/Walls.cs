using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : Building       //стены
{
    public override event BuildDelegate eventLevelUp;

    float armorCore;
    const float upArmorCore = 0.05f;
    public float ArmorCore { get { return armorCore; } }
    public Walls()
    {
        name = "Стены"; 
        lvl = 1;
        SetArmorCore();

        UpPriceImprovement();
    }

    public override void LvlUp()
    {
        lvl++;
        SetArmorCore();
        UpPriceImprovement();
        eventLevelUp?.Invoke(this);
    }

    public void LowerLevel(int level)
    {
        lvl -= level;
        if (lvl < 1) lvl = 1;
        SetArmorCore();
    }

    private void SetArmorCore()
    {
        armorCore = upArmorCore * lvl;
    }
}
