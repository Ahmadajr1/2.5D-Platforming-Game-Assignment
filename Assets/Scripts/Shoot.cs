using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireRate = 3;


    private void Start()
    {
        StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        while (true)
        {
                yield return new WaitForSeconds(fireRate);
                Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
