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
    private int speed = 1;
    private float money = 5.0f;
    private float soups = 1;
    private bool buttonOn1 = true, buttonOn2 = true, buttonOn3 = true, upgrade = false;


    private void OnGUI()
    {
        windowSize = GUI.Window(4, windowSize, shopWindow, "Shop");
    }

    private void shopWindow(int id)
    {
        dragArea = new Rect(0, 0, windowSize.width, windowSize.height / 10);
        if(buttonOn1)
            if (GUI.Button(new Rect(windowSize.width * 0.5f - buttonW / 2, windowSize.height * 0.5f - (buttonH * 2 - (buttonH / 2)), buttonW, buttonH), "Buy Auto Material Maker: $" + money))
            {
                if(upgrade)
                {
                    manager.upgradeMat(money, soups);
                }
                else
                {
                    manager.autoMaterial(speed, money, soups);
                }
                    
            }
        if(buttonOn2)
            if (GUI.Button(new Rect(windowSize.width * 0.5f - buttonW / 2, windowSize.height * 0.5f + buttonH / 2, buttonW, buttonH), "Buy Auto Soup Maker: $" + money))
            {
                if (upgrade)
                {
                    manager.upgradeSoup(money, (int)soups);
                }
                else 
                    manager.autoSoup(speed, money);
                    
            }

        if(buttonOn3)
            if (GUI.Button(new Rect(windowSize.width * 0.5f - buttonW / 2, windowSize.height * 0.5f - buttonH / 2, buttonW, buttonH), "Buy Auto Soup Seller: $" + money))
            {
                if (upgrade)
                {
                    manager.upgradeSell(money, soups);
                }
                else
                    manager.autoSell(speed, money);
            }

        if(!buttonOn1 && !buttonOn2 && !buttonOn3)
        {
            upgrade = true;
            speed /= 10;
            buttonOn1 = true;
            buttonOn2 = true;
            buttonOn3 = true;
            money += 5f;
            soups *= 5;
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
