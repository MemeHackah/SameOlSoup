using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeButton : MonoBehaviour
{
    [SerializeField]
    private screenManager manager;

    public void make()
    {
        manager.addSoup();
    }
}
