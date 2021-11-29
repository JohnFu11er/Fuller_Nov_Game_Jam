using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlatformDeactivateController : MonoBehaviour
{
    [SerializeField] private TextMeshPro _deactivationValue;
    private BinaryController _binaryController;

    void Start()
    {
        _binaryController = GameObject.Find("DisplayOutput").GetComponent<BinaryController>();
    }

    void FixedUpdate()
    {
        if (_deactivationValue.text == _binaryController._decimalOutput.ToString())
        {
            transform.gameObject.SetActive(false);
        } else
            transform.gameObject.SetActive(true);
    }
}