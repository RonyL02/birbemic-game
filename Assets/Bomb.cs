using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionDelaySeconds = 2f;
    public GameObject explosion;
    void Start()
    {
        StartCoroutine(ExecuteAfterDelay());
    }

    IEnumerator ExecuteAfterDelay()
    {
        yield return new WaitForSeconds(explosionDelaySeconds);
        var prefabExplosion = Instantiate(explosion);
        prefabExplosion.transform.position = transform.position;
        Destroy(gameObject);
    }
}
