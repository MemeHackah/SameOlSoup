using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sellButton : MonoBehaviour
{
    [SerializeField]
    private screenManager manager;

    public void sell()
    {
        manager.addMoney();
    }
}
