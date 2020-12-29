using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject drone;

    void Start()
    {

    }

    void Update()
    {
        this.transform.position = new Vector3(drone.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
}
