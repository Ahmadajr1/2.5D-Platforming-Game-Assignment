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
    private bool isOnPlatform = false;
    [SerializeField] private TextMeshProUGUI m_TextComponent;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
    }

    private void Update()
    {
        if (gameObject.transform.parent != null && gameObject.transform.parent.CompareTag("Moving Platform"))
        {
            isOnPlatform = true;
        }
        else
        {
            isOnPlatform = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (CheckGroundStatus() || isOnPlatform))
        {
            isReadyToJump = true;
        }

        FindPlatfromDistanceAbovePlayer();
        m_TextComponent.text = FindPlatfromDistanceBeneathPlayer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if (isReadyToJump)
            jump();
       
    }
  


    private void Move()
    {
        playerVelocity.x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        playerVelocity.y += gravity * Time.deltaTime;

        if (CheckGroundStatus() && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        // To reset the effect of gravity 
        if (CheckGroundStatus() && playerVelocity.y < 0)
            playerVelocity.y = 0;

        if(playerVelocity != Vector3.zero)
            characterController.Move(playerVelocity);
    }

    private void jump()
    {
        isReadyToJump = false;
        playerVelocity.y += Mathf.Sqrt(maxJumpHeight * -0.04f * gravity);
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    private bool CheckGroundStatus()
    {

        RaycastHit hitData;
        Vector3 offset = new Vector3(0, 0.5f, 0);
        float raycastLength = 2.1f;
        Ray landingRay = new Ray(transform.position + offset , Vector3.down);
        Debug.DrawRay(transform.position + offset, Vector3.down, Color.blue, raycastLength);
        if (Physics.Raycast(landingRay, out hitData, raycastLength, LayerMask.GetMask("Platform")))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private string FindPlatfromDistanceBeneathPlayer()
    {
        string distance;
        RaycastHit hitData;
        float raycastLength = 1000f;
        Ray landingRay = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down, Color.red, raycastLength);
        if (Physics.Raycast(landingRay, out hitData, raycastLength, LayerMask.GetMask("Platform")))
        {
            if (hitData.distance > 0)
                distance = "A platform is " + (int)hitData.distance + " units beneath you! ";
            else
                distance = "You are on a platform";
        }
        else
            return "No platform under you";

        return distance;
    }

    private void FindPlatfromDistanceAbovePlayer()
    {
        RaycastHit hitData;
        float raycastLength = 20f;
        Vector3 offset = new Vector3(0, -0.5f, 0);
        Ray landingRay = new Ray(transform.position + offset, Vector3.up);
        Debug.DrawRay(transform.position + offset, Vector3.up, Color.red, raycastLength);
        if (Physics.Raycast(landingRay, out hitData, raycastLength, LayerMask.GetMask("Platform")) && hitData.distance < 10)
        {
            maxJumpHeight = hitData.distance;
        }
        else {
            maxJumpHeight = 10;
        }
    }
}
