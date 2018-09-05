using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Detection : MonoBehaviour
{
    Score_Manager score_manager;
    Obstacle_Manager obstacle_Manager;

    void Start()
    {
        score_manager = GameObject.Find("Game_Manager").GetComponent<Score_Manager>();
        obstacle_Manager = GameObject.Find("Obstacle_Manager").GetComponent<Obstacle_Manager>();
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle") endGame();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle") endGame();
    }

    void endGame()
    {
        score_manager.gameOver = true;
        obstacle_Manager.gameOver = true;
        GetComponent<Turning>().enabled = false;
        GetComponent<Player_Slide>().enabled = false;
        GetComponent<Player_Jump>().enabled = false;
    }
}
