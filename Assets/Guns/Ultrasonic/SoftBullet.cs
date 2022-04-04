using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftBullet : Bullet
{
    public float WaveMagnitude = 1f;
    public float WaveSpeed = 1f;
    private float oX;

    private void Start()
    {
        oX = transform.position.x;
    }
    private void OnTriggerStay(Collider other)
    {
        var chunk = other.GetComponent<ChunkHealth>();
        if (chunk != null)
            chunk.Damage(Damage);
    }

    protected override void Update()
    {
        base.Update();
        transform.position += transform.right * Mathf.Sin(Time.timeSinceLevelLoad * WaveSpeed) * WaveMagnitude * Time.deltaTime;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        //do nothing
    }
}
