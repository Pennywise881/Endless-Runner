using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Bars : MonoBehaviour
{
    [SerializeField]
    float oscillationSpeed;
    float yPos;

    void Start()
    {
        yPos = 0;
    }

    void Update()
    {
        yPos = transform.localPosition.y + (oscillationSpeed * Time.deltaTime);
        if (yPos > 0.81f || yPos < -1.15f) oscillationSpeed = -oscillationSpeed;

        transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);
    }
}
