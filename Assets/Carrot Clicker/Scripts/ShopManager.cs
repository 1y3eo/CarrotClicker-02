using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private UpgradeButton upgradeButton;
    [SerializeField] private Transform upgradeButtonsParent;

    [Header(" Data ")]
    [SerializeField] private UpgradeSO[] upgrades;

    void Start()
    {
        SpawnButtons();
    }

    void Update()
    {
        
    }

    private void SpawnButtons()
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            SpawnButton(i);
           
        }
    }

    private void SpawnButton(int index)
    {
        UpgradeButton upgradeButtonInstance = Instantiate(upgradeButton, upgradeButtonsParent);
        UpgradeSO upgrade = upgrades[index];

        int upgradeLevel = PlayerPrefs.GetInt("Upgrade" + index);

        Sprite icon = upgrade.icon;
        string title = upgrade.title;
        string subtitle = string.Format("lvl{0} (+{1} Cps)", upgradeLevel, upgrade.cpsPerLevel);
        string price = upgrade.GetPrice(upgradeLevel).ToString("F0");

        upgradeButtonInstance.Configure(icon, title, subtitle, price);
    }
}
