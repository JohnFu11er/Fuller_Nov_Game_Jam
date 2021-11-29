using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextShadow : MonoBehaviour
{
    [SerializeField] private TextMeshPro _parentTextMesh;
    private TextMeshPro _textMesh;

    void Start()
    {
        _textMesh = transform.GetComponent<TextMeshPro>();
        _textMesh.text = _parentTextMesh.text;
    }
}
