using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{
    [SerializeField]
    float moveSpeed, turnSpeed;
    [HideInInspector]
    public float turn_angle;
    [HideInInspector]
    public bool hit_obstacle;

    Transform player;

    void Start()
    {
        player = transform.GetChild(0);
    }

    void Update()
    {
        //if (transform.position.y < -10) transform.position = new Vector3(2, 0.357f, transform.position.z);
        if (Input.GetKey(KeyCode.RightArrow) && turn_angle < 30) turn_angle += turnSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.LeftArrow) && turn_angle > -30) turn_angle -= turnSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, turn_angle, 0);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
    }
}
