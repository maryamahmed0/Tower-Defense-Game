using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    buildManager buildManager;
    public TurretBluePrint StandardTurret;
    public TurretBluePrint MissileLauncher;    
    public TurretBluePrint LaserBeamer;    
    void Start()
    {
        buildManager = buildManager.instance;
    }
    public void PurchaseStandradTurret()
    {
        buildManager.SelectTurretToBuild(StandardTurret);
    } 
    public void PurchaseMissileLauncher()
    {
        buildManager.SelectTurretToBuild(MissileLauncher);
    }
    public void PurchaseLaserBeamer()
    {
        buildManager.SelectTurretToBuild(LaserBeamer);
    }
}
