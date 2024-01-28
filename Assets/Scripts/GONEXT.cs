using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GONEXT : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("space"))
        {
            SceneManager.LoadScene(1);
        }
    }
}