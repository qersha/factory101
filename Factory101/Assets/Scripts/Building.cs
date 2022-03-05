using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float cost;
    public float upkeepCost;
    public FactoryResources playerAsFactory;
    void Start()
    {
        playerAsFactory = GameObject.Find("Factory").GetComponent<FactoryResources>();
        InvokeRepeating("Upkeep", 60f, 60f);
    }
    void Upkeep()
    {
        playerAsFactory.money -= upkeepCost;
    }
}
