using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BinaryController : MonoBehaviour
{
    [SerializeField] private GameObject _pad1;
    private GameLogic _script1;
    
    [SerializeField] private GameObject _pad2;
    private GameLogic _script2;
    
    [SerializeField] private GameObject _pad4;
    private GameLogic _script4;

    [SerializeField] private GameObject _pad8;
    private GameLogic _script8;

    [SerializeField] private GameObject _pad16;
    private GameLogic _script16;

    [SerializeField] private GameObject _pad32;
    private GameLogic _script32;

    [SerializeField] private GameObject _pad64;
    private GameLogic _script64;

    [SerializeField] private GameObject _pad128;
    private GameLogic _script128;



    [SerializeField] private TMP_Text _decimalText;
    [SerializeField] private TMP_Text _binaryText;

    public int _decimalOutput;
    public int _binaryOutput;

    private int _is1Int;
    private int _is2Int;
    private int _is4Int;
    private int _is8Int;
    private int _is16Int;
    private int _is32Int;
    private int _is64Int;
    private int _is128Int;

    void Start()
    {
        _script1 = _pad1.GetComponent<GameLogic>();
        _script2 = _pad2.GetComponent<GameLogic>();
        _script4 = _pad4.GetComponent<GameLogic>();
        _script8 = _pad8.GetComponent<GameLogic>();
        _script16 = _pad16.GetComponent<GameLogic>();
        _script32 = _pad32.GetComponent<GameLogic>();
        _script64 = _pad64.GetComponent<GameLogic>();
        _script128 = _pad128.GetComponent<GameLogic>();
    }

    void Update()
    {
        // Debug.Log($"Pad 1 is: {_script1._padActive}");
        CalculateDisplay();
        // Debug.Log(_decimalOutput);
        _decimalText.text = _decimalOutput.ToString();
        _binaryText.text = _binaryOutput.ToString();
    }

    void CalculateDisplay()
    {

        if (_script1._padActive) _is1Int = 1;
            else _is1Int = 0;
        if (_script2._padActive) _is2Int = 1;
            else _is2Int = 0;
        if (_script4._padActive) _is4Int = 1;
            else _is4Int = 0;
        if (_script8._padActive) _is8Int = 1;
            else _is8Int = 0;
        if (_script16._padActive) _is16Int = 1;
            else _is16Int = 0;
        if (_script32._padActive) _is32Int = 1;
            else _is32Int = 0;
        if (_script64._padActive) _is64Int = 1;
            else _is64Int = 0;
        if (_script128._padActive) _is128Int = 1;
            else _is128Int = 0;

        _decimalOutput =
            ( 1 * _is1Int) +
            ( 2 * _is2Int) +
            ( 4 * _is4Int) +
            ( 8 * _is8Int) +
            ( 16 * _is16Int) +
            ( 32* _is32Int) +
            ( 64 * _is64Int) +
            ( 128 * _is128Int);

        _binaryOutput =
            ( 1 * _is1Int) +
            ( 10 * _is2Int) +
            ( 100 * _is4Int) +
            ( 1000 * _is8Int) +
            ( 10000 * _is16Int) +
            ( 100000* _is32Int) +
            ( 1000000 * _is64Int) +
            ( 10000000 * _is128Int);
    }
}
