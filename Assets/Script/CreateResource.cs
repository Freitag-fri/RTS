using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CreateResource 
{
    
    // Update is called once per frame
    public static GameResources Updateh(Core core)
    {
        GameResources createResource = new GameResources(100, 100, 0);    //люди товары кредиты 
        GameResources bufPercent = new GameResources(0, 0, 0);
        createResource.Cash += core.resources.People / 10;              // +10%   кредитов от людей 
        
        foreach(Building i in core.building)
        {
            if(i is ICreateResurces)      //ищем здание которые увеличивают производсво ресурсов 
            {
                ICreateResurces percent = (ICreateResurces)i;
                bufPercent += percent.NewResurse();                                //сумируем все бонусы к ресурсам (в %)           
            }
        }
        createResource.PercentOfNumber(bufPercent);             //добавляем бонусы
        return createResource;
    }
}

