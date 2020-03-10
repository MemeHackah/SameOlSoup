using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMatMaker : MonoBehaviour
{
    public float matPerSecond;
    private Rect windowSize = new Rect(450, 50, 250, 200);
    private float timer;
    public float soups;
    public ItemHandler manager;
    // Start is called before the first frame update
    void Start()
    {
        matPerSecond = 1;
        timer = 1;
        manager = GameObject.FindGameObjectWithTag("Tracker").GetComponent<ItemHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            manager.addMaterials(soups);
            timer = matPerSecond;
        }
    }
    
    private void OnGUI()
    {
        windowSize = GUI.Window(5, windowSize, autoWindow, "AutoMaker");
    }

    private void autoWindow(int id)
    {
        Rect dragArea = new Rect(0, 0, windowSize.width, windowSize.height / 10);
        GUI.DragWindow(dragArea);
    }
}
