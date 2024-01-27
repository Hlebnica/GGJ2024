using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitAndDurka : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(5);
    }
}