using UnityEngine;

public class Controller : MonoBehaviour
{
    public WorldGenerator worldGenerator;
    [SerializeField] private float screwForce = 25.0f;
    [SerializeField] private float minimalForce = 10.0f;
    [SerializeField] private float ForwardMovementSpeed = 2.5f;

    private Transform drone;
    private Rigidbody2D body;

    const float lowerBorder = -3.0f;
    const float upperBorder = 3.0f;

    public bool alive { get; private set; } = true;

    public float GetSpeed() {

        return ForwardMovementSpeed;
    }

    public void StartGame() {

        drone.position = new Vector2(drone.position.x, 0.0f);
    }

    public void Explose() {

        SpecialEffects.Instance.CreateExplosion(drone.position);
        alive = false;
        worldGenerator.GameOver();
        Destroy(this.gameObject); 
    }

    void Start()
    {
        drone = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (WorldGenerator.pause) {

            return;
        }

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
