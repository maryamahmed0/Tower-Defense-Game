using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildManager : MonoBehaviour
{
    public static buildManager instance;
    TurretBluePrint turretToBuild;
    Node SelectedNode;
    public TurretUI turretUI;
    public GameObject buildEffect;
    private void Awake()
    {
        if(instance!=null)
        {
            return;
        }
        instance = this;
    }
    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        SelectedNode = null;
        turretUI.Hide();
    }
    public void SelectNode(Node node)
    {
        if (SelectedNode == node)
        {
            DeselectNode();
            return;
        }
        SelectedNode = node;
        turretToBuild = null;
        turretUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        SelectedNode = null;
        turretUI.Hide();
    }
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool NoMoney { get { return PlayerStats.Money < turretToBuild.cost; } }
    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild; 
    }

}
