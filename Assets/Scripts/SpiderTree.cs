using UnityEngine;

public class SpiderTree : KickTrigger
{
    public GameObject spider;
    public Transform hunterTarget;

    public Move hunter1;
    public Move hunter2;

    public Rigidbody hunter1RB;
    public Rigidbody hunter2RB;

    public Rigidbody campfire;


    public override void onKick()
    {
        if (spider.activeInHierarchy) return;

        campfire.isKinematic = false;
        spider.SetActive(true);
        hunter1.move = true;
        hunter1.targetPosition = hunterTarget.position;
        hunter2.move = true;
        hunter2.targetPosition = hunterTarget.position;
        hunter1RB.isKinematic = false;
        hunter2RB.isKinematic = false;
    }
}