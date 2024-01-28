using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform player;
    public DeathAnim DeathAnim;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        var t = 0f;
        while (true)
        {
            yield return new WaitForEndOfFrame();
            t = t + Time.deltaTime;
            if (t > 0.3) 
                 break;
            transform.localScale = Vector3.one * (t + 1);
        }

        Destroy(gameObject);

        print(Vector3.Distance(player.position, transform.position));
        if (Vector3.Distance(player.position, transform.position) < 5)
        {
            print("AAAAA");
            DeathAnim.ebash();
        }
    }
}