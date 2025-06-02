using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbBehaviour : MonoBehaviour
{
    public AudioSource crickSound;
    public float speed = 5f;
    public float sightRange = 15f;
    public float viewAngle = 90f; // field of view angle
    public LayerMask obstacleMask; // Should include "Tree" layer
    private Transform player;
    private Animator anim;

    private Vector3 currentDestination;
    public float wanderDistance = 10f;
    public float destinationTolerance = 1f;
    private float timeSinceLastDestination = 0f;
    public float wanderCooldown = 3f; // seconds between picking new destinations


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

        ChooseNewDestination();
    }

    void Update()
    {

        Vector3 directionToPlayer = player.position - transform.position;
        float distance = directionToPlayer.magnitude;


        bool playerDetected = false;
        if (distance <= sightRange)
        {
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
            if (angleToPlayer <= viewAngle * 0.5f)
            {
                // Check for tree or wall blocking line of sight
                if (!Physics.Raycast(transform.position, directionToPlayer.normalized, distance, obstacleMask))
                {
                    // Debug.Log("found");
                    if (!crickSound.isPlaying)
                    {
                        crickSound.Play();
                    }
                    MoveToPlayer();
                    playerDetected = true;
                }
                else
                {
                    crickSound.Stop();
                }
            }
        }

        if (!playerDetected)
        {
            crickSound.Stop();
            Wander();
        }
    }

    private void MoveToPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(player);
    }

    private void Wander()
    {
        timeSinceLastDestination += Time.deltaTime;

        // If close to current destination or it's time for a new one, pick a new one
        if (Vector3.Distance(transform.position, currentDestination) < destinationTolerance || timeSinceLastDestination > wanderCooldown)
        {
            ChooseNewDestination();
        }

        Vector3 direction = (currentDestination - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(currentDestination);
    }

    private void ChooseNewDestination()
    {
        // Pick a random direction
        Vector3 randomDirection = Random.insideUnitSphere;
        randomDirection.y = 0; // Stay on same plane
        randomDirection.Normalize();

        currentDestination = transform.position + randomDirection * wanderDistance;
        timeSinceLastDestination = 0f;
    }
}
