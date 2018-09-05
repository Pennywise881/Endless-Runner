using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating_Platform : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
    }
}
