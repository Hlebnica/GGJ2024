using UnityEngine;

public class CageDoor : KickTrigger
{
    public Rigidbody rb;
    public Move wolf;
    public Transform wolfTarget;
    public Boss boss;

    public AudioSource audioSource;

    public override void onKick()
    {
        audioSource.Play();
        rb.isKinematic = false;
        wolf.move = true;
        wolf.targetPosition = wolfTarget.position;
        boss.phase1();
        Destroy(this);
    }
}