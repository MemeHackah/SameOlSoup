using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactWindow : MonoBehaviour
{
    [SerializeField]
    private Rect windowSize = new Rect(350, 200, 350, 300);
    [SerializeField]
    private int buttonW = 300;
    [SerializeField]
    private int buttonH = 50;
    private Rect dragArea;
    public ItemHandler manager;
    private bool buttonOn = true;
    private List<string> badDeeds = new List<string>(new string[] {"Pay off senator for more soup", 
                                                                   "Sacrifice members of the soup cult", 
                                                                   "Take over a country for the glory of soup",
                                                                   "Destroy all other sources of food"});
    private string deed;

    void Start()
    {
        deed = badDeeds[Random.Range(0, badDeeds.Count)];
    }
    public void OnGUI()
    {
        manager = GameObject.FindGameObjectWithTag("Tracker").GetComponent<ItemHandler>();
        windowSize = GUI.Window(9, windowSize, artifactWindow, "Artifact");
    }

    private void artifactWindow(int id)
    {
        dragArea = new Rect(0, 0, windowSize.width, windowSize.height / 10);
        if (buttonOn)
            if (GUI.Button(new Rect(windowSize.width * 0.5f - buttonW / 2, windowSize.height * 0.5f - (buttonH * 2 - (buttonH / 2)), buttonW, buttonH), deed + ": +500 Karma"))
            {
                manager.addKarma(500);
                buttonOn = false;
            }
        if (GUI.Button(new Rect(windowSize.width * 0.5f - buttonW / 2, windowSize.height * 0.5f + buttonH / 2, buttonW, buttonH), "Get 1000 SOUPS: -1000 Karma"))
        {
            manager.spendKarma(1000);
            manager.addSoup(1000);
        }
        if (GUI.Button(new Rect(windowSize.width * 0.5f - buttonW / 2, windowSize.height * 0.5f - buttonH / 2, buttonW, buttonH), "Upgrade Soup code: -1000 Karma"))
        {
            manager.spendKarma(1000);
            manager.changeValue(manager.soupValue * 2);
        }

        if(!buttonOn)
        {
            buttonOn = true;
            deed = badDeeds[Random.Range(0, badDeeds.Count)];
        }
        GUI.DragWindow(dragArea);
    }
}
