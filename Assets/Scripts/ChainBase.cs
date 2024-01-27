using UnityEngine;

public class ChainBase : KickTrigger
{
    public Boss boss;

    public override void onKick()
    {
        if (boss.phase != 0)
        {
            boss.chainKick();
            Destroy(gameObject);
        }
    }
}