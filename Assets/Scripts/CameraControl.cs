using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameObject _player;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z);
    }
}
