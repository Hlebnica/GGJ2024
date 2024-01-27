using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Koster : KickTrigger
{
    public SpiderTree tree;
    public DeathAnim playerDeath;
    public Rigidbody hunter1;
    public Rigidbody hunter2;
    public Move hunter1Move;
    public Move hunter2Move;

    public override void onKick()
    {
        if (tree.isDone) return;
        playerDeath.ebashWait();
        hunter1.isKinematic = false;
        hunter2.isKinematic = false;
        hunter1Move.move = true;
        hunter1Move.targetPosition = playerDeath.transform.position;
        hunter2Move.move = true;
        hunter2Move.targetPosition = playerDeath.transform.position;
    }
}