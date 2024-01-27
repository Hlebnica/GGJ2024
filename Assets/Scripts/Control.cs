using System;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Rigidbody lleg;
    public Rigidbody rleg;

    public Rigidbody body;

    private Move move;

    private void Start()
    {
        move = GetComponent<Move>();
    }

    private void Update()
    {
        changeTarget();
        kick();
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
            move.targetPosition = hit.point;
            move.move = true;
        }
    }
}