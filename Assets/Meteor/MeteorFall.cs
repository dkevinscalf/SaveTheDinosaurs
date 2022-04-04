using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeteorFall : MonoBehaviour
{
    public GameObject DeathEffect;
    public bool Crashed;
    private List<ChunkHealth> Chunks;
    public float Velocity;
    // Start is called before the first frame update
    void Start()
    {
        Chunks = GetComponentsInChildren<ChunkHealth>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * Velocity * Time.deltaTime;
        if(!Crashed && !Chunks.Any(o=>o!=null))
        {
            Destroy(this.gameObject);
            Instantiate(DeathEffect);
        }
    }
}
