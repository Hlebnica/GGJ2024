using System;
using UnityEngine;

public class PlayerBarier : MonoBehaviour
{
    public Transform barier;

    private void Update()
    {
        if (transform.position.z < barier.position.z)
        {
            var pos = transform.position;
            pos.z = barier.position.z;
            transform.position = pos;
        }
    }
}