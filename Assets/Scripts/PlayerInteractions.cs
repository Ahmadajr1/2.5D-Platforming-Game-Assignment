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
        //Reloading takes time. Previously I attempted to move the player to initial position instead but reallized later that can mess level events (Like dead enemies stay dead)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
