using System.Collections;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FmsScript : MonoBehaviour
{
    public Text scoreText;
    public static int score = 0;
    public static bool won = false; // 1
    public AudioSource collectSound;
    public GameObject spawn;
    public AudioSource hitSound;
    CharacterController controller;
    public Transform cameraTransform; // 2 camera
    public float playerSpeed = 5;

    public float mouseSensitivity = 3;  //1
    Vector2 look;

    Vector3 velocity; // 7 person
    public float mass = 1f;
    public float jumpSpeed = 5f;
    //character

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        //2 locked mouse
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        UpdateLook(); //2
        UpdateMovement();  //3
        UpdateGravity();   //4
    }

    void UpdateLook()
    {   //2
        look.x += Input.GetAxis("Mouse X") * mouseSensitivity;   //2 camera
        look.y += Input.GetAxis("Mouse Y") * mouseSensitivity; //2  camera
        //Returns rotation z,x,y degrees around the z,x,y applied in that order.
        look.y = Mathf.Clamp(look.y, -90, 90);
        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0); //2.1
        transform.localRotation = Quaternion.Euler(0, look.x, 0); //2   player
    }
    void UpdateMovement()
    {   //3
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var input = new Vector3();
        input += transform.forward * z;
        input += transform.right * x;
        input = Vector3.ClampMagnitude(input, 1f);

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y += jumpSpeed;
        }
        controller.Move((input * playerSpeed/*9*/ + velocity) * Time.deltaTime);
    }
    private void UpdateGravity()
    {     //4  

        var gravity = Physics.gravity * mass * Time.deltaTime;
        //Check CharacterController touching the ground during the last move?
        velocity.y = controller.isGrounded ? -1 : velocity.y + gravity.y;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {

            score++;
            scoreText.text = "Coins: "+score.ToString();
            collectSound.Play();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("birb"))
        {
            Die();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "birb")
        {
            Die();
        }
    }

    void Die()
    {
        cameraTransform.parent = null;
        cameraTransform.gameObject.AddComponent<Rigidbody>();
        cameraTransform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down);
        won = false;
        Debug.Log("Player Died!");
        StartCoroutine(DestroySelf());
    }

    public IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
    }
}

