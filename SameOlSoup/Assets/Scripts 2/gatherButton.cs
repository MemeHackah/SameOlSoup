using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gatherButton : MonoBehaviour
{
    [SerializeField]
    private screenManager manager;

    public void gather()
    {
        manager.addMaterial();
    }
}
