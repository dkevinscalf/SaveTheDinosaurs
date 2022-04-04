using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkCollision : MonoBehaviour
{
    public GameObject DestroyEffect;
    public string earthTag = "Earth";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != earthTag)
            return;
        GetComponentInParent<MeteorFall>().Crashed = true;
        if (DestroyEffect != null)
            Instantiate(DestroyEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
