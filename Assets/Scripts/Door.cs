using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int nextSceneIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null && other.attachedRigidbody.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}