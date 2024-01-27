using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool move = false;
    public Vector3 targetPosition;
    public Rigidbody body;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        go();
    }

    void go()
    {
        if (!move) return;
        var pos = body.position;
        var dist = Vector3.Distance(targetPosition, pos);
        if (dist < 0.1)
        {
            move = false;
            return;
        }


        var targetVector = (targetPosition - pos).normalized;
        body.AddForce(targetVector * 1000f, ForceMode.Force);
        var lok = Quaternion.LookRotation(targetVector);
        body.MoveRotation(Quaternion.Lerp(body.rotation, lok, Time.deltaTime * 4));
        // body.AddTorque(0, -a/10 * Time.deltaTime, 0, ForceMode.VelocityChange);
        // transform.position = pos + targetVector * (speed * Time.deltaTime);
        // transform.rotation = Quaternion.LookRotation(targetVector);
        // var eulers = transform.rotation.eulerAngles;
        // eulers.x = 0;
        // transform.rotation = Quaternion.Euler(eulers);
    }

}