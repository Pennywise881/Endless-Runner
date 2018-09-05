using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField]
    Text coin_text;

    [SerializeField]
    float rotating_speed;
    MeshRenderer theRenderer;
    AudioSource audio_source;

    void Start()
    {
        audio_source = GetComponent<AudioSource>();
        theRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        transform.Rotate(Vector3.right * rotating_speed * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audio_source.Play();
            theRenderer.enabled = false;
            int numberOfCoins = int.Parse(coin_text.text) + 1;
            coin_text.text = numberOfCoins.ToString();
        }
    }
}
