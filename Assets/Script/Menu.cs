using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    GameObject panelTemplate;
    GameObject panel;            //сделать закрытой для юнити
    GameObject panelParent;
    List<Building> building = new List<Building>();                               //список зданий
    List<GameObject> ListPanels = new List<GameObject>();   //список строк
    Core parentCore;
    int deltaTop;

    public Menu(GameObject panelTemplate, GameObject panelParent, Core parentCore)
    {
        this.panelTemplate = panelTemplate;
        this.panelParent = panelParent;
        this.parentCore = parentCore;
        deltaTop = 30;      //растояни между строчками

       // this.panelParent.SetActive(false);
        panelTemplate.SetActive(false);
    }

    void LisseningLevelUpBuilds(Building build)
    {

        build.eventLevelUp += InformationBuildLevelUp;
    }

    void NoneLisseningLevelUpBuilds()
    {
        for (int i = 0; i < building.Count; i++)
        {
            building[i].eventLevelUp -= InformationBuildLevelUp;
        }
    }

    void InformationBuildLevelUp(Building build)
    {
        ListPanels[build.NumberBuildInInformation].transform.Find("lvl").GetComponent<Text>().text = build.Lvl.ToString();
        ListPanels[build.NumberBuildInInformation].transform.Find("Name").GetComponent<Text>().text = build.Name.ToString();
    }

    public void AddNewBuilds(Building build)
    {
        build.NumberBuildInInformation = ListPanels.Count;       //присваиваем обекту номер строчки
        panel = Instantiate(panelTemplate);
        panel.transform.SetParent(panelParent.transform);
        RectTransform rt = panel.GetComponent<RectTransform>();
        rt.localScale = panelTemplate.GetComponent<RectTransform>().localScale;
        rt.anchoredPosition = panelTemplate.GetComponent<RectTransform>().anchoredPosition;
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, rt.anchoredPosition.y - deltaTop * ListPanels.Count);


        Building buf = build;
        panel.transform.Find("lvl").GetComponent<Text>().text = buf.Lvl.ToString();
        panel.transform.Find("Name").GetComponent<Text>().text = buf.Name.ToString();
        panel.transform.Find("lvlUp").GetComponent<Button>().onClick.AddListener(delegate { parentCore.LvlupBuilding(buf); });        //если без буф, то ошибка

        building.Add(build);
        ListPanels.Add(panel);
        panel.transform.Find("lvlUp").gameObject.GetComponent<InformationLvlUp>().building = buf;
        panel.SetActive(true);
        LisseningLevelUpBuilds(build);
    }
}
