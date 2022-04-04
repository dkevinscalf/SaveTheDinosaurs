using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject[] MeteorSchedule;
    public float MeteorCD = 4f;
    public float MeteorSpeedMultiplier = 1f;
    private Queue<GameObject> MeteorQueue;

    // Start is called before the first frame update
    void Start()
    {
        MeteorQueue = new Queue<GameObject> (MeteorSchedule);
        SpawnNextMeteor();
    }

    public void SpawnNextMeteor()
    {
        var meteors = Instantiate(MeteorQueue.Dequeue(), transform.position, Quaternion.identity);
        foreach(var meteor in meteors.GetComponentsInChildren<MeteorFall>())
        {
            meteor.Velocity *= MeteorSpeedMultiplier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
