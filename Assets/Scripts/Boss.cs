using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    public int phase = 0;
    public GameObject pushka;
    public Move nyamnyam;
    public Transform nyamnyamPos;

    public GameObject bananaPrefab;

    public float bananatimer = 0;

    public Light light;
    public GameObject light2;
    public GameObject upChain;
    public Rigidbody cakeRb;
    public GameObject cage;


    public void chainKick()
    {
        if (phase == 3) win();
        if (phase == 2) phase3();
        if (phase == 1) phase2();
    }

    public void phase1()
    {
        if (phase != 0) return;
        phase = 1;
        pushka.SetActive(true);
        nyamnyam.move = true;
        nyamnyam.targetPosition = nyamnyamPos.position;
        cage.SetActive(false);
        // злой нямням
        // появляется пушка
    }

    public void phase2()
    {
        if (phase != 1) return;
        phase = 2;

        print("PHASE 2");
        // бананы падают
    }

    private void Update()
    {
        if (phase == 2 || phase == 3)
        {
            bananatimer += Time.deltaTime;
            if (phase == 3) bananatimer += Time.deltaTime;
            if (bananatimer > .4)
            {
                bananatimer = 0;
                Instantiate(bananaPrefab,
                    new Vector3(Random.Range(-10, 10), 20, Random.Range(-10, 10)).normalized * Random.Range(15, 23),
                    Quaternion.identity);
            }
        }
    }

    public void phase3()
    {
        if (phase != 2) return;
        phase = 3;
        print("PHASE 3");
        // свет отключается
        light.color = Color.black;
        light2.SetActive(true);
    }

    public void win()
    {
        if (phase != 3) return;
        phase = 4;
        light.color = Color.white;
        light2.SetActive(true);
        upChain.SetActive(false);
        cakeRb.isKinematic = false;
    }
}