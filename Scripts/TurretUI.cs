using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    Node target;
    public GameObject ui;
    public Text upgradedCostTxt;
    public Button UpgradeBtn;
    public Text SellCostTxt;
    public void SetTarget(Node target)
    {
        this.target = target;
        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
        if (!target.isUpgraded)
        {
            upgradedCostTxt.text = "$" +target.turretBluePrint.upgradedCost.ToString();
            UpgradeBtn.interactable = true;
        }
        else
        {
            upgradedCostTxt.text = "MAX";
            UpgradeBtn.interactable = false;
        }
        SellCostTxt.text = "$" + target.turretBluePrint.GetSellAmount().ToString();
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        buildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurrit();
        buildManager.instance.DeselectNode();
    }
}
