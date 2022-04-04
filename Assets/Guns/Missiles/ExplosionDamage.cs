using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public float Range = 1f;
    public float Damage = 1f;
    // Start is called before the first frame update
    void Start()
    {
        var launcher = GameObject.Find("MissileLauncher");
        Debug.Log(launcher);
        Damage *= launcher.GetComponent<PlayerGun>().DamageMultiplier;
        foreach(var chunk in FindObjectsOfType<ChunkHealth>().Where(o => o.transform.Distance(transform) <= Range))
        {
            chunk.Damage(Damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
