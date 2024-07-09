using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint
{
    public GameObject turretPrefab;
    public int cost;

    public GameObject UpgradedTurretPrefab;
    public int upgradedCost;

    public int GetSellAmount()
    {
       return cost/2; 
    }
}
