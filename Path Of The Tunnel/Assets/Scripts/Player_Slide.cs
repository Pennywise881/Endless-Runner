using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Slide : MonoBehaviour
{
    [SerializeField]
    float slide_speed, slide_timer;
    float slide_angle;
    Transform player;

    Turning turning;
    Player_Jump player_Jump;
    [SerializeField]
    bool slide_up;

    void Start()
    {
        turning = this.GetComponent<Turning>();
        player_Jump = this.GetComponent<Player_Jump>();
        player = transform.GetChild(0);
    }


    void Update()
    {
        if (slide_up && slide_angle < 0)
        {
            slide_angle += slide_speed * Time.deltaTime;
            if (slide_angle >= 0) slide_timer = 3;
        }
        else if (player_Jump.grounded && Input.GetKey(KeyCode.DownArrow) && slide_angle > -90 && !slide_up)
        {
            slide_angle -= slide_speed * Time.deltaTime;
            slide_timer -= Time.deltaTime;
            if (slide_timer <= 0) slide_up = true;
        }
        else if (slide_angle < 0) slide_angle += slide_speed * Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            slide_up = false;
            slide_timer = 3;
        }
        player.transform.rotation = Quaternion.Euler(slide_angle, turning.turn_angle, 0);
    }
}
