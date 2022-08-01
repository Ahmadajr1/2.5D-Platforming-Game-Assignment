using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private Vector3 startingPostion;
    [SerializeField] private Vector3 endingPosition;
    [SerializeField] private float speed = 0.5f;

    // Start is called before the first frame update

    void Start()
    {
        startingPostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        OnAnimatorMove();
    }

    private void OnAnimatorMove()
    {
        transform.position = Vector3.Lerp(startingPostion, endingPosition, Mathf.PingPong(speed * Time.time, 1));
    }
}
