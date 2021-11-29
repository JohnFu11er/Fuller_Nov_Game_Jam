using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ExitDoorControlBinary : MonoBehaviour
{
    [SerializeField] private GameObject _closedDoor;
    [SerializeField] private GameObject _openDoor;
    [SerializeField] private TextMeshPro _doorOpenValue;
    private BinaryController _binaryController;
    private bool _isDoorOpen;    
    private bool _isLeaving;

    void Start()
    {
        _binaryController = GameObject.Find("DisplayOutput").GetComponent<BinaryController>();
    }

    void FixedUpdate()
    {
        if (_doorOpenValue.text == _binaryController._binaryOutput.ToString())
        {
            // Debug.Log("Open The Door");
            _isDoorOpen = true;
            _openDoor.SetActive(true);
            _closedDoor.SetActive(false);
        }
        else 
        {
            _isDoorOpen = false;
            _openDoor.SetActive(false);
            _closedDoor.SetActive(true);
        }

        if (Input.GetButtonDown("Vertical")) _isLeaving = true;
            else _isLeaving = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && _isDoorOpen && _isLeaving)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}