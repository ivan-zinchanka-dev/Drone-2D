using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Controller : MonoBehaviour
{
    [SerializeField] private WorldGenerator _worldGenerator = null;
    [SerializeField] private float _screwForce = 25.0f;
    [SerializeField] private float _minimalForce = 10.0f;
    [SerializeField] private float _forwardMovementSpeed = 2.5f;

    [SerializeField] private Transform _drone = null;
    [SerializeField] private Rigidbody2D _body = null;

    const float LowerBorder = -3.0f;
    const float UpperBorder = 3.0f;

    public float ForwardMovementSpeed { get { return _forwardMovementSpeed; } }
    public bool IsAlive { get; private set; } = true;

    public void StartGame() {

        _drone.position = new Vector2(_drone.position.x, 0.0f);
    }

    public void Explose() {

        SpecialEffects.Instance.CreateExplosion(_drone.position);
        IsAlive = false;
        _worldGenerator.GameOver();
        Destroy(this.gameObject); 
    }

    void Start()
    {
        if(_drone == null) _drone = GetComponent<Transform>();
        if(_body == null) _body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (WorldGenerator.Pause) {

            return;
        }

        bool screwActive = Input.GetMouseButton(0);

        Vector2 newVelocity = _body.velocity;
        newVelocity.x = _forwardMovementSpeed;
        _body.velocity = newVelocity;

        if (_drone.position.y <= LowerBorder)
        {
            _body.AddForce(new Vector2(0, _screwForce));
        }
        else if (_drone.position.y >= UpperBorder) {

            _body.AddForce(new Vector2(0, -1 * _minimalForce));
        }
        else if (screwActive)
        {
            _body.AddForce(new Vector2(0, _screwForce));
        }

    }
}
