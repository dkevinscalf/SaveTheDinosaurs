using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DamageUpgrade : MonoBehaviour, IUpgradeable
{
    public float[] Values;
    public float CurrentValue;
    public PlayerGun[] Guns;
    private Queue<float> valueQueue;
    public Text ValueText;
    public bool IsActive = true;
    public void DoUpgrade()
    {
        CurrentValue = valueQueue.Dequeue();
        foreach(var gun in Guns)
        {
            gun.DamageMultiplier = CurrentValue;
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

public interface IUpgradeable
{
    public void DoUpgrade();
    public bool IsAvailable();
    public void Activate();
}