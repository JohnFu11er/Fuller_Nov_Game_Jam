using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] public bool _padActive;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("PuzzleBlock")) _padActive = true;
        // Debug.Log("colliding");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _padActive = false;
    }
}
