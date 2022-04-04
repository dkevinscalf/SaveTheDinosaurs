using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBulletUpgrade : MonoBehaviour, IUpgradeable
{
    public GameObject[] Bullets;
    private Queue<GameObject> bulletQueue;
    public PlayerGun[] Guns;
    public bool IsActive = true;
    public void DoUpgrade()
    {
        foreach (var gun in Guns)
        {
            gun.Bullet = bulletQueue.Dequeue();
        }

        UpgradeStore.HidePanel();
    }

    public bool IsAvailable()
    {
        return IsActive && bulletQueue.Any();
    }

    private void Start()
    {
        bulletQueue = new Queue<GameObject>(Bullets);
    }

    private void Update()
    {
    }

    public void Activate()
    {
        IsActive = true;
    }
}