using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float range;
    [SerializeField] float speed;
    private float offset = -10;
    Rigidbody followerRB;

    void Start()
    {
        followerRB = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float distanceBetweenObjects = Vector3.Distance(transform.position, target.transform.position);
        if (transform.position.x > target.transform.position.x)
            offset = -Mathf.Abs(offset);
        else
            offset = Mathf.Abs(offset);

        if (distanceBetweenObjects <= range)
        {
            followerRB.MovePosition(new Vector3(transform.position.x + (target.transform.position.x + offset - transform.position.x) * speed * Time.fixedDeltaTime, transform.position.y, transform.position.z));
        }
    }
}
