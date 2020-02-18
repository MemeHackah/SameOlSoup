using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{
    private int soupCount;
    private int materialCount;
    private float moneyCount;
    public Text moneyText;
    public Text soupText;
    public Text materialText;
    public float materialValue;
    public float soupValue;
    public float soupCost;
    
    // Start is called before the first frame update
    void Start()
    {
        soupCount = 0;
        materialCount = 0;
        moneyCount = 0f;
    }

    public int getSoup()
    {
        return soupCount;
    }
    public int getMaterial()
    {
        return materialCount;
    }

    public float getMoney()
    {
        return moneyCount;
    }

    public void addSoup()
    {
        if(materialCount >= materialValue)
        {
            soupCount += 1;
            soupText.text = "Soup: " + soupCount;
            materialCount -= (int)materialValue;
            materialText.text = "Materials: " + materialCount;
        }
    }

    public void addMaterials()
    {
        materialCount += 1;
        materialText.text = "Materials: " + materialCount;
    }

    public void addMoney()
    {
        if (soupCount >= soupValue)
        {
            moneyCount += soupCost;
            moneyText.text = "Money: " + moneyCount;
            soupCount -= (int)soupValue;
            soupText.text = "Soup: " + soupCount;
        }
    }

    public void spendMoney(float money)
    {
        moneyCount -= money;
        moneyText.text = "Money: " + moneyCount;
    }
}
