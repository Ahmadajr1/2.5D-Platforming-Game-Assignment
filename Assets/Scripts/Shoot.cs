using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireRate = 3;
    GameObject player;
    Coroutine fireCoroutine;
    private bool isFiring = false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }


    private void Update()
    {
        if (!isFiring && Vector3.Distance(player.transform.position, transform.position) < 50)
        {
            isFiring = true;
            fireCoroutine = StartCoroutine("Fire");
        }
        else if(isFiring && Vector3.Distance(player.transform.position, transform.position) > 50)
        {
            StopCoroutine(fireCoroutine);
            isFiring = false;
        }
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
