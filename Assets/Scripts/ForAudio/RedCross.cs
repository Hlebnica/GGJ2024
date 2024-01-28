using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCross : MonoBehaviour
{
    public static event System.Action<int> OnMusicChangeRequest;
    public Transform bodyTransform;
    public ControlPlayerMove player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(bodyTransform.position, player.transform.position);

        if (distance < 1.0f)
        {
            OnMusicChangeRequest?.Invoke(1);
        }

    }

    
}
