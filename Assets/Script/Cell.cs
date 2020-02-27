using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    Something somethingObj;
    public GameObject background;
    public Something SomethingObj
    {
        get { return somethingObj; }
        set
        { 
            background.GetComponentInChildren<MeshRenderer>().material.color = value.Draw(); 
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
