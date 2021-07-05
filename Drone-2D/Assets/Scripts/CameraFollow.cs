using UnityEngine;

[RequireComponent(typeof(Controller))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _drone = null; 
    [SerializeField] private float _offset = 0.0f;              // 4.0f
    [SerializeField] private float _retard = 1.0f;               // 0.5f 
    private Controller _controller = null;

    private void Start()
    {
        _controller = _drone.GetComponent<Controller>();
    }

    private void Update()
    {
        if (_controller.IsAlive)
        {
            this.transform.position = new Vector3(_drone.transform.position.x + _offset, this.transform.position.y, this.transform.position.z);
        }
        else {

            transform.Translate(_controller.ForwardMovementSpeed * _retard * Time.deltaTime, 0, 0);
        }       
    }
}
