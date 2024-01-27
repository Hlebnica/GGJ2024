using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restater : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}