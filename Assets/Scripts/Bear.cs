using System;
using System.Collections;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public Rigidbody hand1;
    public Rigidbody hand2;
    public Rigidbody rb;
    public Move bearMove;
    public Control playerControl;
    public DeathAnim deathAnim;

    public bool attack = false;

    private void OnCollisionEnter(Collision other)
    {
        // print(other.articulationBody.tag);
        if (other.transform.CompareTag("Player") && !attack && !bearMove.move)
        {
            attack = true;
            rb.isKinematic = false;
            hand1.AddForce((hand1.position - other.transform.position).normalized * 5,
                ForceMode.Impulse);
            hand2.AddForce((hand2.position - other.transform.position).normalized * 5,
                ForceMode.Impulse);
            bearMove.move = true;
            bearMove.targetPosition = other.transform.position;
            print("attack");
            playerControl.alive = false;
            StartCoroutine(attackAnim());
        }
    }

    IEnumerator attackAnim()
    {
        yield return new WaitForSeconds(3);
        bearMove.move = true;
        bearMove.targetPosition = new Vector3(-100, 0, -100);
        deathAnim.ebash();
    }
}