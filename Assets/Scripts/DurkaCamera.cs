using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DurkaCamera : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        var time = 0f;
        while (time < 1)
        {
            time += Time.deltaTime;

            yield return new WaitForEndOfFrame();
            Camera.main.transform.rotation = Quaternion.Euler(
                Vector3.Lerp(new Vector3(0, 149.62f, 0), new Vector3(8.44f, 257.37f, 0), time)
            );
        }
    }
}