using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionDelaySeconds = 2f;
    void Start()
    {
        StartCoroutine(ExecuteAfterDelay());
    }

    IEnumerator ExecuteAfterDelay()
    {
        yield return new WaitForSeconds(explosionDelaySeconds);
        Destroy(gameObject);
    }
}
