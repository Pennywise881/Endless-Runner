using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    GameObject[] paths;

    float zPos;
    int index;

    void Start()
    {
        zPos = paths.Length * 10;
        index = 0;
    }

    void Update()
    {
        if (player.position.z > transform.position.z) movePath();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") movePath();
    }

    void movePath()
    {
        transform.position = new Vector3(1.91f, 0.5f, transform.position.z + 10);
        paths[index++ % paths.Length].transform.position = new Vector3(0, 0, zPos);
        zPos += 10;
    }
}
