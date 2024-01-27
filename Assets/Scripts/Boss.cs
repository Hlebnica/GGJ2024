using UnityEngine;

public class Boss : MonoBehaviour
{
    public int phase = 0;
    public GameObject pushka;
    public Move nyamnyam;
    public Transform nyamnyamPos;

    public void phase1()
    {
        if (phase != 0) return;
        phase = 1;
        pushka.SetActive(true);
        nyamnyam.move = true;
        nyamnyam.targetPosition = nyamnyamPos.position;
        // злой нямням
        // появляется пушка
    }

    public void phase2()
    {
        if (phase != 1) return;
        phase = 2;
        // бананы падают
    }

    public void phase3()
    {
        if (phase != 2) return;
        phase = 3;
        // свет отключается
    }
}