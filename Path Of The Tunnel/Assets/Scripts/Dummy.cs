using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle") print("YEs");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Obs_Barrel") print("Trigger");
    }
}
