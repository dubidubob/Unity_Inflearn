using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _speed = 10.0f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * _speed;
        if (Input.GetKey(KeyCode.S))
            transform.position -= new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * _speed;
        if (Input.GetKey(KeyCode.A))
            transform.position -= new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime * _speed;
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime * _speed;
    }
}
