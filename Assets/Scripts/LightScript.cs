using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{

    [SerializeField] GameObject anObject;
    
    float detectionLimit = 53;
    Light light;

    private void Start()
    {
        light = gameObject.GetComponent<Light>();
        if (gameObject.CompareTag("Light 7"))
            light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Light 7") && Vector3.Distance(anObject.transform.position, transform.position) < detectionLimit)
        {
            light.enabled = true;
        } else if(gameObject.CompareTag("Light 7") && Vector3.Distance(anObject.transform.position, transform.position) > detectionLimit)
            light.enabled = false;

        transform.LookAt(anObject.transform);
    }
}
