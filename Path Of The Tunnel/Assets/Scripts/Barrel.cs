using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField]
    float moveSpeed, rotateSpeed;

    Rigidbody rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, 1) * -moveSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        rBody.AddTorque(new Vector3(-rotateSpeed, 0, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            moveSpeed = 0;
            rotateSpeed = 0;
            rBody.angularVelocity = Vector3.zero;
        }
    }
}
