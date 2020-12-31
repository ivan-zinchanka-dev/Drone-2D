using UnityEngine;

public class BirdAI : MonoBehaviour
{

    [SerializeField] private float speed = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
    }
}
