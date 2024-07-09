using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    Renderer rend;
    public Color HoverColor;
    public Color HoverOverTurret;
    Color NodeColor;
    public Vector3 PosOffset;
    buildManager buildManager;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded=false;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        NodeColor = rend.material.color;
        buildManager = buildManager.instance;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret != null || buildManager.NoMoney)
        {
            rend.material.color = HoverOverTurret;
        }
        else
        {
            rend.material.color = HoverColor;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = NodeColor;
    }
    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
            return;
        BuildTurret(buildManager.instance.GetTurretToBuild());
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + PosOffset;
    }
    void BuildTurret(TurretBluePrint bluePrint)
    {
        if (PlayerStats.Money < bluePrint.cost)
            return;

        PlayerStats.Money -= bluePrint.cost;  

        
        GameObject turret = (GameObject)Instantiate(bluePrint.turretPrefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;

        GameObject buildEff = (GameObject)Instantiate(buildManager.instance.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEff,3f);
        turretBluePrint = bluePrint;
    }
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBluePrint.upgradedCost)
            return;

        PlayerStats.Money -= turretBluePrint.upgradedCost;

        Destroy(this.turret);
        
        GameObject turret = (GameObject)Instantiate(turretBluePrint.UpgradedTurretPrefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;

        isUpgraded = true;
    }
    public void SellTurrit()
    {
        PlayerStats.Money += turretBluePrint.GetSellAmount();
        Destroy(turret);    
        turretBluePrint = null;
    }
}
