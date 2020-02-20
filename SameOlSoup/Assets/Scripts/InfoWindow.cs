using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoWindow : MonoBehaviour
{
    [SerializeField]
    private Rect windowSize = new Rect(250, 100, 250, 200);
    private Rect dragArea;
    [SerializeField]
    private ItemHandler manager;

    private void OnGUI()
    {
        windowSize = GUI.Window(3, windowSize, infoWindow, "Status");
    }

    private void infoWindow(int id)
    {
        GUI.Label(new Rect(25, 25, windowSize.width - 50, 25), manager.moneyText);
        GUI.Label(new Rect(25, 50, windowSize.width - 50, 25), manager.soupText);
        GUI.Label(new Rect(25, 75, windowSize.width - 50, 25), manager.materialText);
        dragArea = new Rect(0, 0, windowSize.width, windowSize.height / 10);
        GUI.DragWindow(dragArea);
    }
}
