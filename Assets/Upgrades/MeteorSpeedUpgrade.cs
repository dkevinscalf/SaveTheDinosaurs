using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MeteorSpeedUpgrade : MonoBehaviour, IUpgradeable
{
    public float[] Values;
    public float CurrentValue;
    private Queue<float> valueQueue;
    public Text ValueText;
    public GameObject ParticleEffect;
    public void DoUpgrade()
    {
        CurrentValue = valueQueue.Dequeue();
        foreach(var spawner in FindObjectsOfType<MeteorSpawner>())
        {
            spawner.MeteorSpeedMultiplier = CurrentValue;
        }
        ParticleEffect.SetActive(true);
        UpgradeStore.HidePanel();
    }

    public bool IsAvailable()
    {
        return valueQueue.Any();
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
        throw new System.NotImplementedException();
    }
}