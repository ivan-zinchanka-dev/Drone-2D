using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private ForegroundObject[] blocks;
    [SerializeField] private ForegroundObject[] bird;

    
    public static float x_pos { get; private set; }

    public static float GetGameX() {

        return x_pos;
    }

    void Start()
    {
        ObjectsPool blocksPool = new ObjectsPool(blocks, 12);
        ObjectsPool birdsPool = new ObjectsPool(bird, 4);

        x_pos = 0;
    }

    void Update()
    {
        x_pos = transform.position.x;
    }
}
