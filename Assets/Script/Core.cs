using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Core : Building, Something
{
    Color color;

    public GameResources resources;
    public int peopleLimit;
    public int armyLimit;

    public WorkShop workShop;
    public Storage storage;
    public Walls walls;
    public Barrack barrack;
    public Portal portal;
    public override event BuildDelegate eventLevelUp;
    public event AddPeopleDelegate eventAddPeople;
    public event AddArmyDelegate eventAddArmy;

    public List<Building> building = new List<Building>();       //список зданий
    protected const int addLimetPeople = 1000;
    protected const int addLimetArmy = 200;
    public GameObject PositionCore { get; set; }

    public Core(Color color, GameObject positionCore)
    {        
        this.color = color;
        this.PositionCore = positionCore;
        lvl = 1;
        name = "База";
        peopleLimit = 1000;

        building.Add(this);
        this.eventAddArmy += AddLimitArmy;
        this.eventAddPeople += AddLimitPeople;

        workShop = new WorkShop();
        building.Add(workShop);

        storage = new Storage();
        storage.eventAddPeople += AddLimitPeople;
        building.Add(storage);

        walls = new Walls();
        building.Add(walls);

        barrack = new Barrack();
        barrack.eventAddArmy += AddLimitArmy;
        building.Add(barrack);

        portal = new Portal();
        building.Add(portal);

        resources = new GameResources(200, 300, 500, 0);
        UpPriceImprovement();
    }

    public void AddLimitPeople(int addPeople)
    {
        peopleLimit += addPeople;
    }
    public void AddLimitArmy(int addArmy)
    {
        armyLimit += addArmy;
    }
    public override void LvlUp()
    {
        building.Add(new WorkShop());
        building.Add(new Storage());


        walls.LowerLevel(5);
        lvl++;
        eventLevelUp?.Invoke(this);
        eventAddPeople?.Invoke(addLimetPeople);
    }

    public Color Draw()
    {
        return color;
    }
    enum trstd { g, gf,sdf};
    
    public void Characteristic()
    {
        
    }

    new void UpPriceImprovement()
    {
        priceImprovement = new GameResources(500, 1000, 1000);
    }

    public void GameSteps()
    {
        resources += CreateResource.Updateh(this);
        if (resources.People > peopleLimit) resources.People = peopleLimit;     //переделать
    }
    public void LvlupBuilding(Building obj)            //ап здания
    {
        if(resources.People > obj.PriceImprovement.People && resources.Cash > obj.PriceImprovement.Cash && resources.Goods > obj.PriceImprovement.Goods)
        {
            resources.People -= obj.PriceImprovement.People;
            resources.Cash -= obj.PriceImprovement.Cash;
            resources.Goods -= obj.PriceImprovement.Goods;
            obj.LvlUp();
        }
    }
}

public class CorePlayer : Core
{
    Menu menu;
    GameObject panelParent;
    GameObject panelTemplate;
    public override event BuildDelegate eventLevelUp;
    public new event AddPeopleDelegate eventAddPeople;
    public new event AddPeopleDelegate eventAddArmy;
    public CorePlayer(Color color, GameObject positionCore, GameObject panelParent, GameObject panelTemplate) :base (color, positionCore)
    {
        this.eventAddPeople += AddLimitPeople;
        this.eventAddArmy += AddLimitArmy;
        this.panelParent = panelParent;
        this.panelTemplate = panelTemplate;
    }

    public override void LvlUp()
    {
        WorkShop workShop = new WorkShop();
        building.Add(workShop);
        menu.AddNewBuilds(workShop);
        walls.LowerLevel(5);

        Storage storage = new Storage();
        building.Add(storage);
        menu.AddNewBuilds(storage);
        storage.eventAddPeople += AddLimitPeople;

        lvl++;

        eventLevelUp?.Invoke(this);
        eventAddPeople?.Invoke(addLimetPeople);
        eventAddArmy?.Invoke(addLimetArmy);
    }
    public void CreateMenu()
    {
        if(menu == null)
        {
            menu = new Menu(panelTemplate, panelParent, this);
            foreach (Building i in building)
            {
                menu.AddNewBuilds(i);
            }
        }      
    }
}
