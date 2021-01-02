using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private ForegroundObject[] blocks;
    [SerializeField] private ForegroundObject bird;
    [SerializeField] private BackgroundObject background;
    
    
    public static float x_pos { get; private set; }

    public static float GetGameX() {

        return x_pos;
    }

    private void CreateObjectsPool(ForegroundObject[] source, int size) {

        int index;

        for (int i = 0; i < size; i++)
        {
            index = Random.Range(0, source.Length);
            ForegroundObject current = Instantiate(source[index]);
            current.transform.position = new Vector3(-15.0f, 0.0f, 1.0f);
        }
    }

    private void CreateObjectsPool(ForegroundObject source, int size)
    {
        for (int i = 0; i < size; i++)
        {
            ForegroundObject current = Instantiate(source);
            current.transform.position = new Vector3(-15.0f, 0.0f, 1.0f);
        }
    }

    public void CreateObjectsPool(BackgroundObject source, Transform parent, int size)
    {
        for (int i = 0; i < size; i++)
        {
            BackgroundObject current = (BackgroundObject)Object.Instantiate(source);
            current.transform.position = new Vector3(-10.0f, 0.0f, 1.0f);
        }
    }


    void Start()
    {
        //ObjectsPool blocksPool = new ObjectsPool(blocks, 12);
        //ObjectsPool birdsPool = new ObjectsPool(bird, 4);
        //ObjectsPool backgroundPool = new ObjectsPool(background, parent, 1);

        CreateObjectsPool(blocks, 12);
        CreateObjectsPool(bird, 4);
        CreateObjectsPool(background, parent, 1);


        x_pos = 0;
    }

    void Update()
    {
        x_pos = transform.position.x;
    }
}
