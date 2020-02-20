using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWindow : MonoBehaviour
{
    [SerializeField]
    private Rect windowSize = new Rect(250, 100, 250, 200);
    [SerializeField]
    private int buttonW = 200;
    [SerializeField]
    private int buttonH = 50;
    private Rect dragArea;
    [SerializeField]
    private ItemHandler manager;
    private bool buttonOn1 = true, buttonOn2 = true, buttonOn3 = true;

    private void OnGUI()
    {
        windowSize = GUI.Window(4, windowSize, shopWindow, "Shop");
    }

    private void shopWindow(int id)
    {
        dragArea = new Rect(0, 0, windowSize.width, windowSize.height / 10);
        if(buttonOn1)
            if (GUI.Button(new Rect(windowSize.width * 0.5f - buttonW / 2, windowSize.height * 0.5f - (buttonH * 2 - (buttonH / 2)), buttonW, buttonH), "Buy Auto Material Maker: $5"))
            {
                manager.autoMaterial(1);
            }
        if(buttonOn2)
            if (GUI.Button(new Rect(windowSize.width * 0.5f - buttonW / 2, windowSize.height * 0.5f + buttonH / 2, buttonW, buttonH), "Buy Auto Soup Maker: $5"))
            {
                manager.autoSoup();
            }

        if(buttonOn3)
            if (GUI.Button(new Rect(windowSize.width * 0.5f - buttonW / 2, windowSize.height * 0.5f - buttonH / 2, buttonW, buttonH), "Buy Auto Soup Seller: $5"))
            {
                manager.autoSell();
            }
        GUI.DragWindow(dragArea);
    }
    public void turnOff(int id)
    {
        if (id == 1)
        {
            buttonOn1 = false;
        }
        else if (id == 2)
        {
            buttonOn2 = false;
        }
        else if(id == 3)
        {
            buttonOn3 = false;
        }
    }
}
