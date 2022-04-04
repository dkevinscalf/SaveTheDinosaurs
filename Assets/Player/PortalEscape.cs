using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEscape : MonoBehaviour
{
    public GameObject TimePortal;
    private bool Escaping;

    internal void Escape()
    {
        if (Escaping)
            return;
        Escaping = true;
        Instantiate(TimePortal, transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
