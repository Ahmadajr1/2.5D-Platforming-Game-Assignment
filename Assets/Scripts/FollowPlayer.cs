using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
    GameObject player;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = new Vector3(0, 7, -10);
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        KeepCameraAboveYLimit();
    }

    private void Follow()
    {
        gameObject.transform.position = player.transform.position + offset;

    }

    private void KeepCameraAboveYLimit()
    {
        float yLimit = 6;
        if (gameObject.transform.position.y < 6)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, yLimit, gameObject.transform.position.z);
        }
    }
}
