using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingTransition : MonoBehaviour
{
    public float Velocity = 100f;
    public float StayTime = 2f;
    public Transform StartPoint;
    public Transform MidPoint;
    public Transform EndPoint;
    public TransitionState State;
    public bool SpawnNextMeteor;
    public bool OpenStore;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch(State)
        {
            case TransitionState.In:
                transform.position = Vector3.MoveTowards(transform.position, MidPoint.position, Velocity * Time.deltaTime);
                CheckMidPosition();
                break;
            case TransitionState.Out:
                transform.position = Vector3.MoveTowards(transform.position, EndPoint.position, Velocity * Time.deltaTime);
                CheckEndPosition();
                break;
            default:
                transform.position = MidPoint.position;
                break;
        }
    }

    private void CheckEndPosition()
    {
        if (transform.Distance(EndPoint) < 0.1f)
        {
            Destroy(transform.parent.gameObject);
            if(SpawnNextMeteor)
                FindObjectOfType<MeteorSpawner>().SpawnNextMeteor();
            if (OpenStore)
                UpgradeStore.Instance.ShowPanel();
        }
    }

    private void CheckMidPosition()
    {
        if (transform.Distance(MidPoint) < 0.1f)
            StartCoroutine(StayCR());
    }

    private IEnumerator StayCR()
    {
        State = TransitionState.Stay;
        yield return new WaitForSeconds(StayTime);
        State = TransitionState.Out;
    }
}

public enum TransitionState
{
    In,
    Stay,
    Out
}
