using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var anim = GetComponent<Animator>();
        anim.SetBool("flying", true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
