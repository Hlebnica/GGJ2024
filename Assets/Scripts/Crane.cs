using System;
using UnityEngine;

public class Crane : MonoBehaviour
{
    public GameObject anchor;
    public GameObject magnit;
    public GameObject cross;

    public static event System.Action<int> OnMusicChangeRequest;

    public bool isReady;
    public bool isDone;

    private void Update()
    {
        if (!isDone)
            magnit.transform.position =
                Vector3.Lerp(anchor.transform.position, cross.transform.position + Vector3.up,
                    (Mathf.Sin(Time.time) + 1) / 2);
        if (isReady && ((Mathf.Sin(Time.time) + 1) / 2) < 0.1)
        {
            OnMusicChangeRequest?.Invoke(2);
            isDone = true;
        }
    }
}