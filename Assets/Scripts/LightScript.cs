using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{

    [SerializeField] GameObject anObject;
    
    // Update is called once per frame
    void Update()
    {
        if(anObject != null)
            transform.LookAt(anObject.transform);
    }
}
