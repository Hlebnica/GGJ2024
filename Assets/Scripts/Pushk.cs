using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pushk : MonoBehaviour
{
    public Move player;
    public Transform playerBody;
    public GameObject bombPrefab;
    public GameObject playerObj;
    public DeathAnim DeathAnim;

    private float time = 0;

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - playerBody.position);
        time += Time.deltaTime;
        if (time > 1)
        {
            time = 0;
            var newBomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
            newBomb.GetComponent<Rigidbody>().AddForce(
                (transform.position - playerBody.position).normalized * -(Random.Range(150, 250)),
                ForceMode.Impulse);
            var b = newBomb.GetComponent<Bomb>();
            b.DeathAnim = DeathAnim;
            b.player = playerObj.transform;
        }
    }
}