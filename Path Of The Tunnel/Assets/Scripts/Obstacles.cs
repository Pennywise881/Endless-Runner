using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float away_distance, from_distance, yPos, xPos;
    public float timeOfStay;

    [SerializeField]
    bool front;
    [HideInInspector]
    public bool run;
    Score_Manager game_manager;

    void Start()
    {
        game_manager = GameObject.Find("Game_Manager").GetComponent<Score_Manager>();
    }

    void Update()
    {
        if (run)
        {
            if (front && transform.position.z < player.position.z - away_distance) transform.position = new Vector3(player.position.x, yPos, player.position.z + from_distance);
            else if (transform.position.z < player.position.z - away_distance) transform.position = new Vector3(xPos, yPos, player.position.z + from_distance);
        }
    }
}
