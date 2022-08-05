using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody bulletRB;
    float bulletSpeed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = gameObject.GetComponent<Rigidbody>();
        bulletRB.AddForce(bulletSpeed * transform.forward);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
