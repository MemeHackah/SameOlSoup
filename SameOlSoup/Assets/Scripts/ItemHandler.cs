using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{
    private int soupCount;
    private int materialCount;
    private float moneyCount;
    public string moneyText;
    public string soupText;
    public string materialText;
    public float materialValue;
    public float soupValue;
    public float soupCost;
    public GameObject autoMat;
    public GameObject autoSeller;
    public GameObject autoSouper;

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
        if (materialCount >= materialValue)
        {
            soupCount += 1;
            soupText = "Soup: " + soupCount;
            materialCount -= (int)materialValue;
            materialText = "Materials: " + materialCount;
        }
    }

    public void addMaterials()
    {
        materialCount += 1;
        materialText = "Materials: " + materialCount;
    }

    public void addMoney()
    {
        if (soupCount >= soupValue)
        {
            moneyCount += soupCost;
            moneyText = "Money: " + moneyCount;
            soupCount -= (int)soupValue;
            soupText = "Soup: " + soupCount;
        }
    }

    public void spendMoney(float money)
    {
        moneyCount -= money;
        moneyText = "Money: " + moneyCount;
    }

    public void autoMaterial(float matPerSec)
    {
        if(moneyCount >= 5f)
        {
            Instantiate(autoMat);
            autoMat.GetComponent<AutoMatMaker>().matPerSecond = matPerSec;
            autoMat.GetComponent<AutoMatMaker>().manager = this.gameObject.GetComponent<ItemHandler>();
            this.GetComponent<ShopWindow>().turnOff(1);
            spendMoney(5f);
        }
        
    }

    public void autoSoup()
    {
        if (moneyCount >= 5f)
        {
            Instantiate(autoSouper);
            autoSouper.GetComponent<AutoSoupMaker>().manager = this.gameObject.GetComponent<ItemHandler>();
            this.GetComponent<ShopWindow>().turnOff(2);
            spendMoney(5f);
        }
    }

    public void autoSell()
    {
        if (moneyCount >= 5f)
        {
            Instantiate(autoSeller);
            autoSeller.GetComponent<AutoSeller>().manager = this.gameObject.GetComponent<ItemHandler>();
            this.GetComponent<ShopWindow>().turnOff(3);
            spendMoney(5f);
        }
    }
}
