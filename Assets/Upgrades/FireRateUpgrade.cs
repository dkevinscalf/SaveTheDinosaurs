using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FireRateUpgrade : MonoBehaviour, IUpgradeable
{
    public float[] Values;
    public float CurrentValue;
    private Queue<float> valueQueue;

    public PlayerGun[] Guns;
    public Text ValueText;
    public bool IsActive = true;
    public void DoUpgrade()
    {
        CurrentValue = valueQueue.Dequeue();
        foreach(var gun in Guns)
        {
            gun.FireCD = CurrentValue;
        }

        UpgradeStore.HidePanel();
    }

    public bool IsAvailable()
    {
        return IsActive && valueQueue.Any();
    }

    private void Start()
    {
        valueQueue = new Queue<float>(Values);
    }

    private void Update()
    {
        ValueText.text = $"{CurrentValue} > {valueQueue.Peek()}";
    }

    public void Activate()
    {
        IsActive = true;
    }
}