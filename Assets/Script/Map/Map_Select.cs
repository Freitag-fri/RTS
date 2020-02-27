using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_Select : MonoBehaviour
{
    public Dropdown dropDown;
    public Image MapPanel;

    public Sprite Map4Players;
    public Sprite Map5Players;
    public Sprite Map6Players;

    List<string> sumPlayers = new List<string>() { "4 players", "5 players", "6 players" };

    void Start()
    {
        PopulateDropDown();
    }

    void PopulateDropDown()
    {
        dropDown.AddOptions(sumPlayers);
    }

    public void index(int value)
    {
        value += 4;

        /*
        if (value == 4)
        {
            MapPanel. = Map5Players;
        }
        else if (value == 5)
        {
            MapPanel.sprite = Map4Players;

        }
        else if (value == 6)
        {
            MapPanel = Map6Players;
        }
        */
    }
}
