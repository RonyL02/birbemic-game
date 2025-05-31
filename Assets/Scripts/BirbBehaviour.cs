using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbBehaviour : MonoBehaviour
{
    public float speed = 5f;
    public float sightRange = 15f;
    public float viewAngle = 90f; // field of view angle
    public LayerMask obstacleMask; // Should include "Tree" layer
    private Transform player;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("flying", true);

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Player not found! Make sure the player GameObject has the 'Player' tag.");
        }
    }

    void Update()
    {

        Vector3 directionToPlayer = player.position - transform.position;
        float distance = directionToPlayer.magnitude;


        if (distance <= sightRange)
        {
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            if (angleToPlayer <= viewAngle * 0.5f)
            {
                // Check for tree or wall blocking line of sight
                if (!Physics.Raycast(transform.position, directionToPlayer.normalized, distance, obstacleMask))
                {
                    MoveToPlayer();
                }
            }
        }
    }

    private void MoveToPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(player);
    }
}
