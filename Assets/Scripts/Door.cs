using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Opening Door");
            doorAnimator.SetBool("isOpen", true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Closing Door");
            doorAnimator.SetBool("isOpen", false);
        }
    }
}
