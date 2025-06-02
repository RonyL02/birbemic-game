using UnityEngine;

public class Present : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(200f, 0f, 0f);

    public GameObject presentBox;

    public GameObject bomb;
    public GameObject coin;

    void Start()
    {

    }
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            rotationSpeed = Vector3.zero;
            gameObject.GetComponent<Collider>().enabled = false;
            Destroy(presentBox);
            var value = Random.Range(0, 2);
            if (value == 0)
            {
                for (int i = 0; i < Random.Range(7, 12); i++)
                {
                    Instantiate(coin, transform);
                }
            }
            else
            {
                Instantiate(bomb, transform);
            }
        }
    }
}
