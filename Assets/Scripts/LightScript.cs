using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    [SerializeField] GameObject platform;


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(platform.transform);
    }
}
