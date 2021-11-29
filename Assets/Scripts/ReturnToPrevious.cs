using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToPrevious : MonoBehaviour
{

    private bool _isLeaving;

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Vertical")) _isLeaving = true;
            else _isLeaving = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && _isLeaving)
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
                SceneManager.LoadScene("MainMenu");

            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
