using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 200f, 0f);
    void Start()
    {

    }
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
    // Update is called once per frame
}
