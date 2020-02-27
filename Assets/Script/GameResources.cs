using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GameResources 
{
    public GameResources(int people, float goods, float cash, int army = 0)
    {
        People = people;
        Goods = goods;
        Cash = cash;
        Army = army;
    }
    public int People { get; set; }
    public float Goods { get; set; }
    public float Cash { get; set; }
    public float Army { get; set; }

    public static GameResources operator +(GameResources c1, GameResources c2)          //сумируем
    {
        return new GameResources { People = c1.People + c2.People, Goods = c1.Goods + c2.Goods, Cash = c1.Cash + c2.Cash, Army = c1.Army + c2.Army};
    }


    /*
    public static GameResources operator *(GameResources c1, GameResources c2)          //берём процент (в с2 проценты, в с1 значения)
    {       
        GameResources buf = new GameResources();

        buf.People = (int)(c1.People * (c2.People / 100f + 1));
        buf.Goods = c1.Goods * (c2.Goods / 100f + 1);
        buf.Cash = c1.Cash * (c2.Cash / 100f + 1);

        return buf;
    }
    */
    public GameResources PercentOfNumber(GameResources c2)          //берём процент (в с2 проценты, в с1 значения)
    {
        GameResources buf = new GameResources();

        buf.People = (int)(People * (c2.People / 100f + 1));
        buf.Goods = Goods * (c2.Goods / 100f + 1);
        buf.Cash = Cash * (c2.Cash / 100f + 1);

        return buf;
    }
}
