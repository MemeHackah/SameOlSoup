using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSoupMaker : MonoBehaviour
{
    public float soupPerSecond;
    private Rect windowSize = new Rect(450, 50, 250, 200);
    private float timer, soups;
    public ItemHandler manager;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
        soupPerSecond = 1;
        manager = GameObject.FindGameObjectWithTag("Tracker").GetComponent<ItemHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            manager.addSoup();
            timer = soupPerSecond;
        }
    }

    private void OnGUI()
    {
        windowSize = GUI.Window(6, windowSize, autoWindow, "AutoSoup");
    }

    private void autoWindow(int id)
    {
        Rect dragArea = new Rect(0, 0, windowSize.width, windowSize.height / 10);
        GUI.DragWindow(dragArea);
    }
}
