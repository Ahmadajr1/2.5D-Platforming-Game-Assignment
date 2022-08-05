using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;


public class PlayerControl : MonoBehaviour
{

    CharacterController characterController;
    private float speed = 10;
    private float gravity = -1f;
    float maxJumpHeight;
    private Vector3 playerVelocity;
    private bool isReadyToJump = false;
    MovePlatform platformScript;
    PlayerFeetCollosionDetector feetScript;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        feetScript = gameObject.transform.Find("PlayerFeet").GetComponent<PlayerFeetCollosionDetector>();

        // Planning to use the Canvas later
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && feetScript.CheckGroundStatus())
        {
            isReadyToJump = true;
        }

        FindPlatfromDistanceAbovePlayer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            Move();
    }
  


    private void Move()
    {
        Vector3 platformVelocity = Vector3.zero;
        if (platformScript != null)
        {
            platformVelocity = platformScript.GetPlatformVelocity();
        }


        playerVelocity.x = Input.GetAxisRaw("Horizontal") * speed * Time.fixedDeltaTime;
        if (feetScript.CheckGroundStatus())
            playerVelocity.y = 0;
        else
            playerVelocity.y += gravity * Time.fixedDeltaTime;

        if (isReadyToJump)
        {
            playerVelocity.y += Mathf.Sqrt(maxJumpHeight * -0.04f * gravity);
            isReadyToJump = false;
            if (transform.parent != null)
                transform.parent.DetachChildren();
        }

        characterController.enabled = false;
        characterController.transform.position = transform.position;
        characterController.transform.rotation = transform.rotation;
        characterController.enabled = true;

        if (playerVelocity != Vector3.zero)
            characterController.Move(playerVelocity + platformVelocity);
    }

   
    private void FindPlatfromDistanceAbovePlayer()
    {
        RaycastHit hitData;
        float raycastLength = 20f;
        Vector3 offset = new Vector3(0, 1, 0);
        Ray landingRay = new Ray(transform.position + offset, Vector3.up);
        string[] layerMasks = { "Platform", "Moving Platform" };

        if (Physics.Raycast(landingRay, out hitData, raycastLength, LayerMask.GetMask(layerMasks)) && hitData.distance < 10)
        {
            maxJumpHeight = hitData.distance;
        }
        else {
            maxJumpHeight = 10;
        }
    }
}
