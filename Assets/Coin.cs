using UnityEngine;

public class Coin : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 1;
    void Start()
    {
        rb.AddForceAtPosition(Vector3.up * force, Vector3.forward * transform.localScale.x);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
