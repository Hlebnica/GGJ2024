using System;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        // transform.position = target.position;
        // var rotation = transform.rotation.eulerAngles;
        // rotation += Vector3.up * (Input.GetAxis("Horizontal") * Time.deltaTime) * 70;
        // transform.rotation = Quaternion.Euler(rotation);

        transform.position +=
            new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * (Time.deltaTime * 14);
    }
}