﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWindow : MonoBehaviour
{
    [SerializeField]
    private Rect windowSize = new Rect(250, 100, 250, 200);
    [SerializeField]
    private int buttonW = 50;
    [SerializeField]
    private int buttonH = 50;
    private Rect dragArea;
    [SerializeField]
    private ItemHandler manager;

    private void OnGUI()
    {
        windowSize = GUI.Window(1, windowSize, collectMaterials, "Gather Materials");
    }

    private void collectMaterials(int id) 
    {
        dragArea = new Rect(0, 0, windowSize.width, windowSize.height / 10);
        if (GUI.Button(new Rect(windowSize.width * 0.5f - buttonW / 2, windowSize.height * 0.5f - buttonH / 2, buttonW, buttonH), "Gather"))
        {
            //Debug.Log("gather button pressed");
            manager.addMaterials();
        }
        GUI.DragWindow(dragArea);
    }
}
