using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Seeker : Bullet
{
    public Transform Target; 
    public float TurnSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        Target = FindObjectsOfType<ChunkHealth>().OrderBy(o=>o.transform.position.y).FirstOrDefault()?.transform;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (Target != null)
            SlowLookRotation();
        else
            Target = FindObjectsOfType<ChunkHealth>().OrderBy(o => o.transform.position.y).FirstOrDefault()?.transform;
    }

    public void SlowLookRotation()
    {
        Vector3 lTargetDir = Target.position - transform.position;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.deltaTime * TurnSpeed);
    }


}
