using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private Vector3 startingPosition;
    private Rigidbody rigidBody;
    private int flipDirection = 1;
    float maxDistance;

    [SerializeField] private Vector3 endingPosition;
    [SerializeField] private float speed = 0.5f;

    void Start()
    {
        startingPosition = transform.position;
        maxDistance = Vector3.Magnitude(endingPosition - transform.position);
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float currentDistance = Vector3.Magnitude(endingPosition - transform.position);
        if (currentDistance < 0.1 || currentDistance > maxDistance)
        {
            flipDirection *= -1;
        }
        rigidBody.MovePosition(endingPosition);
    }

    public Vector3 GetVelocity()
    {
        return rigidBody.velocity;
    }
}
