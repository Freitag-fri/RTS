using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_map : MonoBehaviour
{
    float sizeCubeX;
    float sizeCubeY;
    int sumCubeX;
    int sumCubeY;
    public GameObject[,] playinField;

    public GameObject cell;
    public GameObject map;
    public List<GameObject> PositionCore;
    void Start()
    {
        sizeCubeX = cell.GetComponent<Transform>().localScale.x;
        sizeCubeY = cell.GetComponent<Transform>().localScale.y;
        sumCubeX = 15;
        sumCubeY = 15;
        playinField = new GameObject[sumCubeX, sumCubeY];

    }

    void Update()
    {
        
    }


    public void CreateMap(int numPlayers)
    {
        for (int x = 0; x < sumCubeX; ++x)
        {
            for (int y = 0; y < sumCubeY; ++y)
            {
                playinField[x, y] = Instantiate(cell, new Vector2(x * sizeCubeX, y * sizeCubeY), transform.rotation);
                playinField[x, y].transform.SetParent(map.transform);
            }
        }
        CreatePositionCore(numPlayers);
    }

    void CreatePositionCore(int numPlayers)
    {
        if(numPlayers == 4)
        {
            PositionCore.Add(playinField[sumCubeX - 1, 0]);
            PositionCore.Add(playinField[0, sumCubeY - 1]);
            PositionCore.Add(playinField[sumCubeX -1, sumCubeY -1]);
            PositionCore.Add(playinField[0, 0]);
        }
    }
}
