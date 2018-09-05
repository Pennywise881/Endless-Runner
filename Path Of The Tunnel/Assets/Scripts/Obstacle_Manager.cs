using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject[] obstacles;

    GameObject curObs;

    float obs_timeOfStay, refresh_time;
    int index, prev_index;
    [HideInInspector]
    public bool gameOver;

    void Start()
    {
        prev_index = -1;
        obs_timeOfStay = 3;
        curObs = obstacles[0];
        refresh_time = 5;
    }

    void Update()
    {
        if (!gameOver)
        {
            obs_timeOfStay -= Time.deltaTime;
            if (obs_timeOfStay <= 0 && refresh_time > 0)
            {
                curObs.GetComponent<Obstacles>().run = false;
                refresh_time -= Time.deltaTime;
                // print(refresh_time);
            }
            else if (obs_timeOfStay <= 0 && refresh_time <= 0)
            {
                index = Random.Range(0, obstacles.Length);
                if (index == prev_index)
                {
                    if ((index == 0 || Random.Range(1, 3) == 1) && index < obstacles.Length - 1) index++;
                    else index--;
                }
                prev_index = index;
                // index = 1;
                curObs = obstacles[index];
                obs_timeOfStay = curObs.GetComponent<Obstacles>().timeOfStay;
                refresh_time = 5;
                curObs.GetComponent<Obstacles>().run = true;
            }
        }
    }
}
