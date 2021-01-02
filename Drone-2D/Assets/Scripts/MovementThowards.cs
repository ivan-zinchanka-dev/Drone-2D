using UnityEngine;

public class MovementThowards : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;

    void Update()
    {
        if (WorldGenerator.pause){ return; }

        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
    }


    
}
