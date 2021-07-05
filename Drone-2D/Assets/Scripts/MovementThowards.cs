using UnityEngine;

public class MovementThowards : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    void Update()
    {
        if (WorldGenerator.Pause) return; 

        transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);
    }


    
}
