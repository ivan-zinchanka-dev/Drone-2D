using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _firstPart = null;
    [SerializeField] private GameObject _secondPart = null;
    [SerializeField] private float _speed = default;

    private const float Width = 45.35f;
    private const float Addend = 9.0f;

    private void Move()
    {
        _firstPart.transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);
        _secondPart.transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);
    }

    void Start()
    {
        _secondPart.transform.position = new Vector3(_firstPart.transform.position.x + Width, _firstPart.transform.position.y);
    }

    void Update()
    {
        if (WorldGenerator.Pause) return;
        Move();

        if (transform.position.x > _firstPart.transform.position.x + Width + Addend) { 
        
            _firstPart.transform.position = new Vector3(_secondPart.transform.position.x + Width, _firstPart.transform.position.y);
        }

        if (transform.position.x > _secondPart.transform.position.x + Width + Addend)
        {
            _secondPart.transform.position = new Vector3(_firstPart.transform.position.x + Width, _secondPart.transform.position.y);
        }
    }
}
