using System;
using UnityEngine;

public class Magnit : MonoBehaviour
{
    public Crane crane;
    public Gosling gosling;

    public Rigidbody[] toUnkinematic;
    public GameObject sysBefore;
    public GameObject sysAfter;

    public LineRenderer line;
    public Transform anhor;

    public static event System.Action<int> OnMusicChangeRequest;

    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody != null && other.rigidbody.CompareTag("budka"))
        {
            OnMusicChangeRequest?.Invoke(2);
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

    private void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, anhor.position);
    }
}