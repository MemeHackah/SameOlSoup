﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellWindow : MonoBehaviour
{   
    [SerializeField]
    private Rect windowSize = new Rect(150, 75, 250, 200);
    [SerializeField]
    private int buttonW = 50;
    [SerializeField]
    private int buttonH = 50;
    private Rect dragArea;
    [SerializeField]
    private ItemHandler manager;

    private void OnGUI()
    {
        windowSize = GUI.Window(0, windowSize, sellSoup, "Sell Soup");
    }

    private void sellSoup(int id)
    {
        dragArea = new Rect(0, 0, windowSize.width, windowSize.height / 10);
        if(GUI.Button(new Rect(windowSize.width * 0.5f - buttonW / 2, windowSize.height * 0.5f - buttonH / 2, buttonW, buttonH), "Sell"))
        {
            //Debug.Log("sell button pressed");
            manager.addMoney();
        }
        GUI.DragWindow(dragArea);
    }
}
