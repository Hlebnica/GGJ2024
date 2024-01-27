using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cake: MonoBehaviour
{
    public Boss boss;
    private void OnCollisionEnter(Collision other)
    {
        print(other.gameObject.name);
        if (boss.phase == 4 && other.gameObject.name == "Ground")
            SceneManager.LoadScene(4);
    }
}