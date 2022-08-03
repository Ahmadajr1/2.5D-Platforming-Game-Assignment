using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private Vector3 startingPosition;
    private Vector3 destination;
    private Rigidbody platformRB;
    bool toggleDirection = true;
    [SerializeField] private Vector3 endingPosition;
    [SerializeField] private float speed = 0.5f;

    void Start()
    {
        startingPosition = transform.position;
        destination = endingPosition;
        platformRB = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (toggleDirection)
        {
            if (Vector3.Distance(transform.position, destination) < 0.2)
            {
                destination = startingPosition;
                toggleDirection = false;
            }
        }
        else 
        {
            if (Vector3.Distance(transform.position, destination) < 0.2)
            {
                destination = endingPosition;
                toggleDirection = true;
            }
        }

        platformRB.MovePosition(transform.position + (destination - transform.position).normalized * speed * Time.fixedDeltaTime);
    }

    public Vector3 GetPlatformVelocity()
    {
        return (destination - transform.position).normalized * speed * Time.fixedDeltaTime;
    }

}
