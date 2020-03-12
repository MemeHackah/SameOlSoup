using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenManager : MonoBehaviour
{
    private int soupCount;
    [SerializeField]
    private int materialCount;
    private float moneyCount;

    private int manualGatherRate = 1;
    private float soupValue = 1.25f;
    private int manualSoupRate = 1;
    private int soupCost = 5;

    public string moneyText;
    public string soupText;
    public string materialText;

    private float timer;

    void Start()
    {
        soupCount = 0;
        materialCount = 0;
        moneyCount = 0f;
        timer = 30;
    }

    void Update()
    {
        materialText = "Materials: " + materialCount;
        soupText = "Soup: " + soupCount;
        moneyText = "Money: " + moneyCount;
    }

    public void addMaterial() { materialCount += manualGatherRate; }
    public void addSoup() {
        if (materialCount >= soupCost) {
            soupCount += manualSoupRate;
            materialCount -= soupCost;
        }
    }
    public void addMoney() {
        if (soupCount > 0) {
            soupCount -= 1;
            moneyCount += soupValue;
        }
    }
}
