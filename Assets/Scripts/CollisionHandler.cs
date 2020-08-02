using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;
    

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequnce();
    }

    void StartDeathSequnce()
    {
        SendMessage("OnPlayerDeath");
        //deathFX.SetActive(true);
        Instantiate(deathFX, transform.position, Quaternion.identity);
        Invoke("LoadCurrentScene", levelLoadDelay);
        
    }

    void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
