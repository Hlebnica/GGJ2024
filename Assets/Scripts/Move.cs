using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool move = false;
    public Vector3 targetPosition;
    public float speed = 1;
    public Rigidbody body;
    public Rigidbody lleg;
    public Rigidbody rleg;

    public LayerMask kickLayer;

    public LayerMask walkLayer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        changeTarget();
        go();
        kick();
    }

    void go()
    {
        if (!move) return;
        var pos = body.transform.position;
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

    void kick()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        print("kik");
        if (Physics.Raycast(ray, out hit, 100)) //, 1 << LayerMask.NameToLayer("Kickable")
        {
            print("wtf?");
            // targetPosition = hit.point;
            // move = true;

            //Check when there is a new collider coming into contact with the box

            var center = body.position +
                         Quaternion.LookRotation(hit.point - body.transform.position) * Vector3.forward * 3;
            Collider[] hitColliders = Physics.OverlapSphere(center, 3, 1 << LayerMask.NameToLayer("Kickable"));
            int i = 0;
            Debug.Log(hitColliders);
            while (i < hitColliders.Length)
            {
                var collider = hitColliders[i];
                print(collider.name);
                var clb = collider.attachedRigidbody;
                print(body);
                clb.AddForce((body.position - center).normalized * -10000, ForceMode.Impulse);


                i++;
            }

            var kuda = (body.position - center).normalized * -100;
            lleg.AddForce(kuda, ForceMode.Impulse);
            rleg.AddForce(kuda, ForceMode.Impulse);
        }
    }


    void changeTarget()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, 1 << LayerMask.NameToLayer("Walkable")))
        {
            targetPosition = hit.point;
            move = true;
        }
    }
}