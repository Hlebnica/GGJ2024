using System;
using UnityEngine;

public class Magnit : MonoBehaviour
{
    public Crane crane;
    public Gosling gosling;

    private void OnCollisionEnter(Collision other)
    {

        if (other.rigidbody != null && other.rigidbody.CompareTag("budka"))
        {
            crane.isReady = true;
            other.rigidbody.transform.SetParent(transform);
            gosling.forward = true;
            Destroy(this);
        }
    }
}