using System;
using UnityEngine;

public class Pushk : MonoBehaviour
{
    public Move player;
    public Transform playerBody;

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - playerBody.position);
    }
}