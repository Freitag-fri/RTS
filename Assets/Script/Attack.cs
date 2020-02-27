using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public GameObject menyAttack;

    public GameObject panel;
    public RectTransform perentForPanel;

    [Header("Ползунок для выбора количества")]
    public Slider sliderSpeed;
    public Slider sliderRush;
    public Slider sliderDef;

    
    [Header("Доступное количесво для выбора")]
    public Text textMaxUnitSpeed;
    public Text textMaxUnitRush;
    public Text textMaxUnitDef;

    [Header("Выбранное количество")]
    public Text textTakenUnitSpeed;
    public Text textTakenUnitRush;
    public Text textTakenUnitDef;

    void Start()
    {
      
        sliderSpeed.wholeNumbers = true;        //только целые числа
        sliderRush.wholeNumbers = true;
        sliderDef.wholeNumbers = true;

        menyAttack.SetActive(false);
    }

    public void PickEnemy()
    {
        UpDateWindow();
        CreateEnemy();
        Squad squad = GetComponent<MainControl>().playerCore.barrack.unitSquad;
        textMaxUnitSpeed.text = squad.unitSpeed.SumUnit.ToString(); 
        sliderSpeed.maxValue = squad.unitSpeed.SumUnit;
        textMaxUnitRush.text = squad.unitRush.SumUnit.ToString();
        sliderRush.maxValue = squad.unitRush.SumUnit;
        textMaxUnitDef.text = squad.unitDef.SumUnit.ToString();
        sliderDef.maxValue = squad.unitDef.SumUnit;

        sliderSpeed.value = 0;
        sliderRush.value = 0;
        sliderDef.value = 0;
        menyAttack.SetActive(true);
    }

    void UpDateWindow()
    {
        foreach(Transform child in perentForPanel)
        {
            Destroy(child.gameObject);
        }
    }

    void CreateEnemy()
    {
        Core[] botCore = GetComponent<MainControl>().botCore;
        for (int i = 0; i < botCore.Length; i++)
        {
            GameObject instance = GameObject.Instantiate(panel) as GameObject;
            instance.transform.SetParent(perentForPanel);
            instance.transform.Find("lvl").GetComponent<Text>().text = botCore[i].Lvl.ToString();

            GameObject buf = botCore[i].PositionCore;
            instance.GetComponent<Button>().onClick.AddListener(delegate { Setpos(buf); });   
        }   
    }

    public void SliderChangerSpeed(int value)
    {
        textTakenUnitSpeed.text = sliderSpeed.value.ToString();
    }

    public void SliderChangerRush(int value)
    {
        textTakenUnitRush.text = sliderRush.value.ToString();
    }

    public void SliderChangerDef(int value)
    {
        textTakenUnitDef.text = sliderDef.value.ToString();
    }

    void Setpos(GameObject pos)
    {
        GameObject test = pos;
    }

    public void CloseMenu()
    {
        menyAttack.SetActive(false);
    }
}
