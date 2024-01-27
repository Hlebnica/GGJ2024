using System.Collections;
using UnityEngine;

public class DeathAnim : MonoBehaviour
{
    public Move car;
    public GameObject player;
    public Move sanitar;
    public Move sanitar2;
    public Control playerControl;


    IEnumerator EbashAnimWait()
    {
        yield return new WaitForSeconds(2);
        ebash();
    }

    public void ebashWait()
    {
        if (!playerControl.alive) return;
        playerControl.alive = false;
        StartCoroutine(EbashAnimWait());
    }

    public void ebash()
    {
        car.move = true;
        car.targetPosition = transform.position;
        sanitar.move = true;
        sanitar.targetPosition = transform.position;
        sanitar2.move = true;
        sanitar2.targetPosition = transform.position;
        StartCoroutine(EbashAnim());
    }

    IEnumerator EbashAnim()
    {
        yield return new WaitForSeconds(3);

        car.move = true;
        car.targetPosition = new Vector3(-100, 0, -100);
        sanitar.move = true;
        sanitar.targetPosition = new Vector3(-100, 0, -100);
        sanitar2.move = true;
        sanitar2.targetPosition = new Vector3(-100, 0, -100);


        player.SetActive(false);
    }
}