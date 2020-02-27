using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InformationLvlUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Building building;
    public GameObject textLogo;

    void Start()
    {
        textLogo = transform.Find("Text logo").gameObject;
        textLogo.SetActive(false);
    }

    void Update()
    {
        if(textLogo.activeSelf)     //обновляем окно когда наведены на него
            UpDateLogo();
    }

    public void OnPointerExit(PointerEventData eventData)       //мышка больше не указывает на кнопку
    {
        textLogo.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)      //мышка указывает на кнопку
    {
        textLogo.SetActive(true);
        UpDateLogo();
    }

    void UpDateLogo()
    {
        
        int people = building.PriceImprovement.People;
        float goods = (float)Math.Ceiling(building.PriceImprovement.Goods);
        float cash = (float)Math.Ceiling(building.PriceImprovement.Cash);
        textLogo.transform.GetComponent<Text>().text = "Стоимость улучшения " + people.ToString() + " " + goods.ToString() + " " + cash.ToString();
    }
}
