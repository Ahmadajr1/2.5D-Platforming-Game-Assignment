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
    float maxJumpHeight = 1;
    private Vector3 playerVelocity;
    private bool isReadyToJump = false;
    [SerializeField] private TextMeshProUGUI m_TextComponent;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckGroundStatus())
        {
            isReadyToJump = true;
        }
        m_TextComponent.text = FindPlatfromDistanceBeneathPlayer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if (isReadyToJump)
            jump();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Moving Platform"))
        {
            //transform.position = new Vector3(transform.position.x, collision.gameObject.transform.position.y + 0.5f, transform.position.z);
        }
    }


    private void Move()
    {
        playerVelocity.x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

        if (CheckGroundStatus() && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity);
    }

    private void jump()
    {
        isReadyToJump = false;
        playerVelocity.y += Mathf.Sqrt(maxJumpHeight * -0.3f * gravity);
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    private bool CheckGroundStatus()
    {
        RaycastHit hitData;
        float raycastLength = 0.1f;
        Ray landingRay = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down, Color.red, raycastLength);
        if (Physics.Raycast(landingRay, out hitData, raycastLength))
        {
            Debug.Log(true);
            return true;
        }
        else
        {
            Debug.Log(false);
            return false;
        }
    }

    private string FindPlatfromDistanceBeneathPlayer()
    {
        string distance;
        RaycastHit hitData;
        float raycastLength = 1000f;
        Ray landingRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(landingRay, out hitData, raycastLength))
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
}
