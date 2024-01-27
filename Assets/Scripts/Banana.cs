using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Banana : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            var body = other.rigidbody;
            if (body == null) return;
            body.AddForce(new Vector3(Random.Range(-1000, 1000), Random.Range(-1000, 1000), Random.Range(-1000, 1000)),
                ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}