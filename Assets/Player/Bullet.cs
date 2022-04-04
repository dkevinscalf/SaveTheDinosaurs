using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string GunName;
    public float Damage;
    public float Velocity;
    public GameObject HitEffect;
    public float ShotShake;
    public float Acceleration;
    private bool Dead;
    // Start is called before the first frame update
    void Start()
    {
        if (ShotShake > 0)
            CameraShake.QuickShake(ShotShake);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Acceleration > 0)
            Velocity *= 1 + (Acceleration * Time.deltaTime);
        transform.position += transform.forward * Velocity * Time.deltaTime;
        if (transform.position.magnitude > 100f)
            Destroy(this.gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (Dead)
            return;
        Debug.Log(Dead);
        Dead = true;
        var chunkHealth = other.GetComponent<ChunkHealth>();
        if (chunkHealth != null)
            chunkHealth.Damage(Damage);
        if (HitEffect != null)
            Instantiate(HitEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
