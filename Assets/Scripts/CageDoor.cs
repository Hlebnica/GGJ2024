using UnityEngine;

public class CageDoor : KickTrigger
{
    public Rigidbody rb;
    public Move wolf;
    public Transform wolfTarget;
    public Boss boss;

    public override void onKick()
    {
        rb.isKinematic = false;
        wolf.move = true;
        wolf.targetPosition = wolfTarget.position;
        boss.phase1();
        Destroy(this);
    }
}