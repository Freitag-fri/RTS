using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MainControl: MonoBehaviour
{

    float time;
    public float maxTime;
    public Core[] botCore;
    public CorePlayer playerCore;

    public Text resPeople;
    public Text resGoods;
    public Text resCash;
    public Text armorCore;
    public Text armyCore;

    [Header("Player canvas")]
    public GameObject panelParent;
    public GameObject buttonLvlUp;
    public GameObject CloseMenu;
    public GameObject panelTemplate;
    public GameObject showMenu;

    void Start()
    {
        showMenu.SetActive(false);
        Button but = buttonLvlUp.GetComponent<Button>() as Button;
        but.onClick.AddListener(delegate { ShowMenu(); }); 
        but = CloseMenu.GetComponent<Button>() as Button;
        but.onClick.AddListener(delegate { ShowMenu(); });

        GetComponent<Create_map>().CreateMap(4);            //Количестов игроков!!!
        MapFor4Players();
        playerCore.CreateMenu();                    //сездаем меню для улучшения зданий
        maxTime = 1;
        DrawResurse();
    }

    public void MapFor4Players()
    {
        List<GameObject> positionCore = GetComponent<Create_map>().PositionCore;

        botCore = new Core[3];
        for(int i = 0; i < 3; i++)
        {
            botCore[i] = new Core(new Color(0, 1, 0), positionCore[i]);
            positionCore[i].transform.GetComponent<Cell>().SomethingObj = botCore[i];
        }
        

        playerCore = new CorePlayer(new Color(0, 0, 1), positionCore[3], panelParent, panelTemplate);
        positionCore[3].transform.GetComponent<Cell>().SomethingObj = playerCore; 
    }

    void ShowMenu()
    {
        showMenu.SetActive(!showMenu.activeSelf);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > maxTime)
        {
            playerCore.GameSteps();
            DrawResurse();
            time = 0;
        }
    }

    void DrawResurse()
    {
        resPeople.text = playerCore.resources.People.ToString() + "/" + playerCore.peopleLimit.ToString();
        resGoods.text = Math.Round(playerCore.resources.Goods).ToString();
        resCash.text = Math.Round(playerCore.resources.Cash).ToString();
        armorCore.text = playerCore.walls.ArmorCore.ToString();
        armyCore.text = playerCore.resources.Army.ToString() + "/" + playerCore.armyLimit;
    }
}
