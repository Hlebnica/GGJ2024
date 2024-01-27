using System;
using System.Collections;
using UnityEngine;

public class Gosling : MonoBehaviour
{
    public Rigidbody rb;
    public bool forward = false;
    public Coroutine anim;


    private void Start()
    {
        anim = StartCoroutine(stuckAnim());
    }

    private void Update()
    {
    }

    public IEnumerator stuckAnim()
    {
        while (true)
        {
            rb.AddForce(-20000, 0, 0, ForceMode.Impulse);
            yield return new WaitForSeconds(1);
            rb.AddForce(10000, 0, 0, ForceMode.Impulse);
            yield return new WaitForSeconds(1);
        }
    }
}