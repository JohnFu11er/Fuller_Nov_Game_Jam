using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCollider : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        transform.position += new Vector3(other.rigidbody.velocity.x, 0, 0);
    }
}
