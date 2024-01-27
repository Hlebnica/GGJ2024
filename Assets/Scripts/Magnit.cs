using System;
using UnityEngine;

public class Magnit : MonoBehaviour
{
    public Crane crane;
    public Gosling gosling;

    public Rigidbody[] toUnkinematic;
    public GameObject sysBefore;
    public GameObject sysAfter;

    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody != null && other.rigidbody.CompareTag("budka"))
        {
            crane.isReady = true;
            other.rigidbody.transform.SetParent(transform);
            gosling.forward = true;
            Destroy(this);
            foreach (var rb in toUnkinematic)
            {
                rb.isKinematic = false;
            }

            sysBefore.SetActive(false);
            sysAfter.SetActive(true);
        }
    }
}