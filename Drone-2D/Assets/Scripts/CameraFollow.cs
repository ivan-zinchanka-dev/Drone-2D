using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject drone; 
    [SerializeField] private float offset = 0.0f;
    [SerializeField] private float retard = 1.0f;

    private Controller controller;

    private void Start()
    {
        controller = drone.GetComponent<Controller>();
    }

    private void Update()
    {
        if (controller.alive)
        {
            this.transform.position = new Vector3(drone.transform.position.x + offset, this.transform.position.y, this.transform.position.z);
        }
        else {

            transform.Translate(controller.GetSpeed() * retard * Time.deltaTime, 0, 0);
        }

        
    }
}
