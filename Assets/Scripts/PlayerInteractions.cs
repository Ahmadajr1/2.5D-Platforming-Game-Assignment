using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -10)
        {
            RestartLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        gameObject.transform.position = new Vector3(-23, 2.7f, -5);
    }

}
