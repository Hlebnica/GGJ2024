using System;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Transform barier;
    public GameObject stone;
    public GameObject staticStone;
    public PlayerBarier playerBarier;

    private void Update()
    {
        if (transform.position.z < barier.position.z)
        {
            stone.SetActive(false);
            staticStone.SetActive(true);
            Destroy(this);
            Destroy(playerBarier);
        }
    }
}