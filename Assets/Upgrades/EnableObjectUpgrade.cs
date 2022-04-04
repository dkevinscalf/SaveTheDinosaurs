using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnableObjectUpgrade : MonoBehaviour, IUpgradeable
{
    public GameObject[] Objects;
    public GameObject[] UnlockedUpgrades;
    private Queue<GameObject> objectQueue;
    public bool IsActive = true;

    public void Activate()
    {
        IsActive = true;
    }

    public void DoUpgrade()
    {
        objectQueue.Dequeue().SetActive(true);
        if (UnlockedUpgrades != null)
        {
            foreach(var upgrade in UnlockedUpgrades)
            {
                upgrade.GetComponent<IUpgradeable>().Activate();
            }
        }
        UpgradeStore.HidePanel();
    }

    public bool IsAvailable()
    {
        return IsActive && objectQueue.Any();
    }

    private void Start()
    {
        objectQueue = new Queue<GameObject>(Objects);
    }

    private void Update()
    {
    }
}