using UnityEngine;

public class Coin : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 1;

    void Start()
    {
        Vector3 baseDirection = Vector3.up;

        // Apply a small random rotation around the Z-axis
        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(-10f, 10f));
        Vector3 randomizedDirection = randomRotation * baseDirection;

        // Calculate the force vector
        Vector3 forceVector = randomizedDirection * force;

        // Determine the position to apply the force
        Vector3 position = transform.position + transform.forward * transform.localScale.x;

        // Apply the force at the specified position
        rb.AddForceAtPosition(forceVector, position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
