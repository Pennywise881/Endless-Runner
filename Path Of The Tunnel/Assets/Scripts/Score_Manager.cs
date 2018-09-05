using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject player_container;

    [SerializeField]
    Text distance_text, coin_text, gameOver_message;

    [SerializeField]
    float rate_of_score;
    float distance;
    public bool gameOver;
    bool end_game;

    void Start()
    {
        distance = 0;
    }

    void Update()
    {
        if (!gameOver)
        {
            distance += rate_of_score * Time.deltaTime;
            distance_text.text = distance.ToString("#.00") + " m";
        }
        else if (!end_game)
        {
            calculateScore();
            end_game = true;
        }
    }

    void calculateScore()
    {
        float high_Score_distance = PlayerPrefs.GetFloat("DistanceHighScore");
        float high_Score_coins = PlayerPrefs.GetInt("CoinHighScore");

        int num_of_coin = int.Parse(coin_text.text);
        if (distance > high_Score_distance && num_of_coin > high_Score_coins)
        {
            PlayerPrefs.SetFloat("DistanceHighScore", distance);
            PlayerPrefs.SetInt("CoinHighScore", num_of_coin);

            distance_text.text = "";
            coin_text.text = "";
            gameOver_message.text = "New High Score: " + distance.ToString("#.00") + " m, $" + high_Score_coins.ToString();
        }
        else gameOver_message.text = "High Score: " + high_Score_distance.ToString("#.00") + " m, $" + high_Score_coins.ToString();
        Invoke("ReloadScene", 3);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}