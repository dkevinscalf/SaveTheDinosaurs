using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public float TurnSpeed;



    public Vector3 Front = Vector3.forward;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        
    }

    

    private void HandleRotation()
    {
        Vector3 myLocation = transform.position;
        Vector3 targetLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetLocation.z = myLocation.z;

        Vector3 vectorToTarget = targetLocation - myLocation;
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 0) * vectorToTarget;

        Quaternion targetRotation = Quaternion.LookRotation(forward: Front, upwards: rotatedVectorToTarget);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
    }
}
