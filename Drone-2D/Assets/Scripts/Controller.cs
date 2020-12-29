using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float screwForce = 25.0f;
    [SerializeField] private float minimalForce = 10.0f;
    [SerializeField] private float ForwardMovementSpeed = 10.0f;

    private Transform drone;
    private Rigidbody2D body;

    const float lowerBorder = -3.0f;
    const float upperBorder = 3.0f;

    void Start()
    {
        drone = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        bool screwActive = Input.GetMouseButton(0);

        Vector2 newVelocity = body.velocity;
        newVelocity.x = ForwardMovementSpeed;
        body.velocity = newVelocity;

        if (drone.position.y <= lowerBorder)
        {
            body.AddForce(new Vector2(0, screwForce));
        }
        else if (drone.position.y >= upperBorder) {

            body.AddForce(new Vector2(0, -1 * minimalForce));
        }
        else if (screwActive)
        {
            body.AddForce(new Vector2(0, screwForce));
        }




    }
}
