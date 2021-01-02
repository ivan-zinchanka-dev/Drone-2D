using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject drone;
    [SerializeField] private Controller controller;
    [SerializeField] private float offset = 0.0f;

    private void Start()
    {
        controller = drone.GetComponent<Controller>();
    }

    private void Update()
    {
        if (controller.state)
        {
            this.transform.position = new Vector3(drone.transform.position.x + offset, this.transform.position.y, this.transform.position.z);
        }
        else {

            transform.Translate(controller.GetSpeed() * Time.deltaTime, 0, 0);
        }

        
    }
}
