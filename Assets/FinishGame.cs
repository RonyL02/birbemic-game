using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public GameObject canvas;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FmsScript.won = true;
            if(FmsScript.score > PlayerPrefs.GetInt("score") && FmsScript.won)
            {
                PlayerPrefs.SetInt("score", FmsScript.score);
            }
            SceneManager.LoadScene("GameOver");
        }
    }
}
