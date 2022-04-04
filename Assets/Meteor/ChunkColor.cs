using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunkColor : MonoBehaviour
{
    public float Radius = 2f;
    public float CheckFrequency = 0.5f;
    public Renderer rend;
    public ColorBreak[] Colors;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCheckCR());
    }

    private IEnumerator ColorCheckCR()
    {
        while(true)
        {
            CheckColor();
            yield return new WaitForSeconds(CheckFrequency);
        }
    }

    private void CheckColor()
    {
        var chunkCount = FindObjectsOfType<ChunkColor>().Where(o => o.transform.Distance(transform) < Radius).Count();
        //Debug.Log(chunkCount);
        var material = Colors.Where(o => o.Number <= chunkCount).OrderByDescending(o => o.Number).FirstOrDefault();
        if (material != null)
            rend.material = material.Color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class DistanceHelper
{
    public static float Distance(this Transform a, Transform b)
    {
        return a.position.Distance(b.position);
    }

    public static float Distance(this Vector3 a, Vector3 b)
    {
        return (a - b).magnitude;
    }
}

[Serializable]
public class ColorBreak
{
    public int Number;
    public Material Color;
}