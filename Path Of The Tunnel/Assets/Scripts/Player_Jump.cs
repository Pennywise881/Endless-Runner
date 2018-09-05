using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    [SerializeField]
    float fallMultiplier, lowJumpMultiplier, jumpSpeed;
    bool jump;
    [HideInInspector]
    public bool grounded;
    Rigidbody rBody;

    [SerializeField]
    Transform pivot;
    [SerializeField]
    float ray_dist;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(pivot.position, -Vector3.up * ray_dist, out hit, ray_dist))
        {
            if (hit.collider.tag == "Ground") grounded = true;
        }
        else grounded = false;

        if (Input.GetKeyDown("space") && !Input.GetKey(KeyCode.DownArrow)) jump = true;

        Debug.DrawRay(pivot.position, -Vector3.up * ray_dist, Color.white);
    }

    void FixedUpdate()
    {
        if (jump && grounded)
        {
            rBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            jump = false;

            /* Uncomment the line below to enable double jump & comment out line 27 */
            // grounded = false;
        }

        if (rBody.velocity.y < 0) rBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        else if (rBody.velocity.y > 0 && !Input.GetKey("space")) rBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
    }
}
