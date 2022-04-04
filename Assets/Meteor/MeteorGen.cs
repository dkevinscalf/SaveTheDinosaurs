using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGen : MonoBehaviour
{
    public GameObject ChunkPrefab;
    public float Radius = 2f;
    public float MinRadius = 0;
    public float Scale = 0.5f;
    public float XStep = 0.5f;
    public float YStep = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        float y = 0;
        BuildRow(y);
        while (Radius > MinRadius)
        {
            Radius-= XStep;
            y+= YStep;
            BuildRow(y);
            BuildRow(-y);
        }
    }

    private void BuildRow(float y)
    {
        for(var i = -Radius; i<=Radius; i++)
        {
            Instantiate(ChunkPrefab, transform).transform.localPosition = new Vector3(i * Scale, y * Scale, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
