using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;

    public AudioSource source;

    private bool hasPlayed = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            Debug.Log("Opening Door");
            source.Play();
            hasPlayed = true;
            doorAnimator.SetBool("isOpen", true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Closing Door");
            hasPlayed = false;
            // source.Play();
            doorAnimator.SetBool("isOpen", false);
        }
    }
}
