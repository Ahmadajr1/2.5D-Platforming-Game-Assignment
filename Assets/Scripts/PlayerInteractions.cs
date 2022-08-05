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
            int nextSceneIndex = other.gameObject.GetComponent<EndPlatform>().GetNextSceneIndex();
            SceneManager.LoadScene(nextSceneIndex);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        //Player Starting Position (This will be automated later)
        //Reloading takes time. I attempted to move the player to initial position instead but reallized later that can mess up level events (Like dead enemies stay dead), For now changing position is for level one only
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            gameObject.transform.position = new Vector3(-23, 2.68f, -5);
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
