using System;
using System.Collections;
using UnityEngine;

public class CarFirer : MonoBehaviour
{
    public GameObject fireEffect;
    public GameObject toKill;
    public Move medved;
    public GameObject smoker;
    public GameObject bear;
    public Rigidbody bearRB;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("fire"))
        {
            fireEffect.SetActive(true);
            // Destroy(toKill, 1);
            medved.targetPosition = transform.position;
            medved.move = true;
            bearRB.isKinematic = false;
            if (!smoker.activeInHierarchy)
                StartCoroutine(smokeAnim());
        }
    }

    IEnumerator smokeAnim()
    {
        yield return new WaitForSeconds(2);
        smoker.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Destroy(toKill);
        Destroy(smoker.gameObject, 0.5f);
        Destroy(bear);
    }
}