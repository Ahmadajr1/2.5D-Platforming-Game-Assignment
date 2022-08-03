using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerFeetCollosionDetector : MonoBehaviour
{
    PlayerControl playerControllerScript;
    private void Start()
    {
        playerControllerScript = transform.parent.GetComponent<PlayerControl>();
    }

    private void Update()
    {
        m_TextComponent.text = FindPlatfromDistanceBeneathPlayer();
    }

    [SerializeField] private TextMeshProUGUI m_TextComponent;


    public bool CheckGroundStatus()
    {

        RaycastHit hitData;
        float raycastLength = 100f;

        Ray landingRay = new Ray(transform.position, Vector3.down);
        string[] layerMasks = { "Platform", "Moving Platform" };

        // Deducted 1 from hitData.distance because ray is launced from the center of transform
        if (Physics.Raycast(landingRay, out hitData, raycastLength, LayerMask.GetMask(layerMasks)))
        {
            if (hitData.distance < 0.5f)
            {
                if (hitData.collider.CompareTag("Moving Platform"))
                    transform.parent.parent = hitData.collider.transform;
                return true;
            }
            else if (hitData.distance > 0.5 && transform.parent.parent != null)
            {
                transform.parent.parent = null;
            }
            return false;
        }
        else
            return false;
    }


    //[For debugging purposes] This does nothing in the game other than displaying the distance of nearest platform beneath the player. 
    private string FindPlatfromDistanceBeneathPlayer()
    {
        string distance;
        RaycastHit hitData;
        float raycastLength = 100f;
        Ray landingRay = new Ray(transform.position, Vector3.down);
        string[] layerMasks = { "Platform", "Moving Platform" };
        if (Physics.Raycast(landingRay, out hitData, raycastLength, LayerMask.GetMask(layerMasks)))
        {
            distance = "A platform is " + (hitData.distance).ToString("0.00") + " units beneath you! ";

        }
        else
            return "No platform under you";

        return distance;
    }

}
