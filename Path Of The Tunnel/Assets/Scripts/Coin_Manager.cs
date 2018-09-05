using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Manager : MonoBehaviour
{

    [SerializeField]
    Transform player;
    int xPos;
    [SerializeField]
    float timeBeforeAvailable;
    bool available;
    MeshRenderer[] coinRenderer;

    void Start()
    {
        coinRenderer = GetComponentsInChildren<MeshRenderer>();
        timeBeforeAvailable = 2;
    }

    void Update()
    {
        if (!available) timeBeforeAvailable -= Time.deltaTime;

        if (timeBeforeAvailable <= 0 && !available)
        {
            xPos = Random.Range(1, 6);
            displayAllCoins();
            transform.position = new Vector3(xPos, 1.8f, player.position.z + 30);
            available = true;
            timeBeforeAvailable = 2;
        }
        else if (available && player.position.z > transform.position.z + 10)
        {
            available = false;
        }
    }

    void displayAllCoins()
    {
        foreach (MeshRenderer theRenderer in coinRenderer)
        {
            if (!theRenderer.enabled) theRenderer.enabled = true;
        }
    }
}
