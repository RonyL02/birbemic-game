using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour
{
    public float durationSeconds = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySelf());
    }
    public IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(durationSeconds);
        Destroy(gameObject);
    }
}
