using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeStore : MonoBehaviour
{
    public GameObject StoreWindow;
    public Transform StorePanel;
    public Transform LibraryPanel;
    public static UpgradeStore Instance;
    public float Delay = 1f;
    public float UpgradeInterval = 0.5f;
    private void Awake()
    {
        Instance = this;
    }
    public static void HidePanel()
    {
        Instance.Hide();
    }

    internal static void AddUpgrades(GameObject[] unlockedUpgrades)
    {
        Instance.AddUpgradesToLibrary(unlockedUpgrades);
    }

    private void AddUpgradesToLibrary(GameObject[] unlockedUpgrades)
    {
        foreach (var upgrade in unlockedUpgrades)
        {
            Instantiate(upgrade, LibraryPanel);
        }
    }

    private void Start()
    {
    }

    public void ShowPanel()
    {
        ClearUpgrades();
        if (SelectUpgrades() > 0)
            StoreWindow.SetActive(true);
        else
            Hide();
    }

    public void Hide()
    {
        StoreWindow.SetActive(false);
        FindObjectOfType<MeteorSpawner>().SpawnNextMeteor();
    }

    private int SelectUpgrades()
    {
        var upgradeLibrary = LibraryPanel.GetComponentsInChildren<IUpgradeable>();
        var upgrades = upgradeLibrary.Where(o => o.IsAvailable()).OrderBy(o => Guid.NewGuid()).Select(o => ((MonoBehaviour)o).transform);
        if (upgrades.Count() == 0)
            return 0;
        var selectedUpgrades = upgrades.Take(Mathf.Min(2, upgrades.Count())).ToList();
        StartCoroutine(StoreSetupCR(selectedUpgrades));
        return selectedUpgrades.Count;
    }

    private IEnumerator StoreSetupCR(IEnumerable<Transform> upgrades)
    {
        yield return new WaitForSeconds(Delay);
        foreach (var selectedUpgrade in upgrades)
        {
            selectedUpgrade.SetParent(StorePanel);
            yield return new WaitForSeconds(UpgradeInterval);
        }
    }

    private void ClearUpgrades()
    {
        var upgradeList = new List<Transform>();
        foreach(Transform child in StorePanel)
        {
            upgradeList.Add(child);
        }

        foreach(var child in upgradeList)
        {
            child.SetParent(LibraryPanel);
        }
    }
}
