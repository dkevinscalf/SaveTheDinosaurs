using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float TimeToLive = 4f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestructCR());
    }

    private IEnumerator SelfDestructCR()
    {
        yield return new WaitForSeconds(TimeToLive);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
