using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkHealth : MonoBehaviour
{
    public float Health = 5f;
    public float DamageThreshold = 2f;
    public GameObject Cracks;
    public GameObject DeathEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float v)
    {
        if (Health <= 0)
            return;
        Health -= v;
        Cracks.SetActiveSafe(Health <= DamageThreshold);
        if (Health <= 0)
            Die();
    }

    private void Die()
    {
        if (DeathEffect != null)
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

public static class ObjectHelpers
{
    public static void SetActiveSafe(this GameObject self, bool v)
    {
        if (self.activeSelf != v)
            self.SetActive(v);
    }
}
