using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructOrb : MonoBehaviour
{
    public float ScaleSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        CameraShake.QuickShake(3);
        FindObjectOfType<PortalEscape>().Escape();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale *= 1 + (ScaleSpeed * Time.deltaTime);
    }
}
