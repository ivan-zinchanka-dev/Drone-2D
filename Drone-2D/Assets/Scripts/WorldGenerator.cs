using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private ForegroundObject[] blocks;

    public static float x_pos { get; private set; }

    public static float GetGameX() {

        return x_pos;
    }

    void Start()
    {
        ObjectsPool pool = new ObjectsPool(blocks, 12);

        x_pos = 0;
    }

    void Update()
    {
        x_pos = transform.position.x;
    }
}
