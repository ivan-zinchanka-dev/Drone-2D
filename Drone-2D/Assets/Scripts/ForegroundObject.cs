using UnityEngine;

public class ForegroundObject : MonoBehaviour
{
    [SerializeField] private ObjectName name = ObjectName.BIRD;  
    //private static float addend = 10.0f;

    public static float blocks_addend = 10.0f;   // ADDEND
    public static float birds_addend = 10.0f;

    private static float blocks_x = WorldGenerator.x_pos + blocks_addend;
    private static float birds_x = WorldGenerator.x_pos + birds_addend;
    private static bool isUpper = false;
    private static short upperBlocksCount = 0;
    private static short lowerBlocksCount = 0;


    private void Start()
    {
        blocks_x = WorldGenerator.x_pos + blocks_addend;
        birds_x = WorldGenerator.x_pos + birds_addend;
        isUpper = false;
        upperBlocksCount = 0;
        lowerBlocksCount = 0;
    }


    public void SetBirdInWorld() {

        byte creating = (byte) Random.Range(0, 2);

        if (creating != 0)
        {
            float y = Random.Range(-2.5f, 3.0f);
            transform.position = new Vector3(birds_x, y, transform.position.z);
        }     

        birds_x = (birds_x < WorldGenerator.x_pos + birds_addend) ? (WorldGenerator.x_pos + birds_addend) : (birds_x + 3.0f);

    }


    public void SetBlockInWorld() {

        float? y = null;

        Location location = Location.EMPTY;

        if (isUpper)
        {
            isUpper = false;
            y = -2.5f;
            lowerBlocksCount++;
        }
        else
        {

            if (upperBlocksCount + lowerBlocksCount >= 7)
            {
                location = Location.EMPTY;
            }
            else if (upperBlocksCount == 1)
            {
                location = Location.UPPER;
            }
            else if (lowerBlocksCount == 1)
            {

                location = Location.LOWER;
            }
            else
            {
                int value = Random.Range(0, 15);           // EMPTY 0  UPPER 1 LOWER 2

                if (value == 0)
                {
                    location = Location.UPPER;
                }
                else if (value <= 4)
                {
                    location = Location.LOWER;
                }
                else if (value > 4) {

                    location = Location.EMPTY;
                }
               
            }


            if (location == Location.EMPTY)
            {
                isUpper = false;
                upperBlocksCount = 0;
                lowerBlocksCount = 0;

            }
            else if (location == Location.UPPER)
            {
                isUpper = true;
                y = -0.24f;
                upperBlocksCount++;
            }
            else if (location == Location.LOWER)
            {
                isUpper = false;
                y = -2.5f;
                lowerBlocksCount++;
            }

        }

        if (y != null) {

            transform.position = new Vector3(blocks_x, (float)y, transform.position.z);
        }
        
        if (!isUpper) {

            blocks_x += 2.54f;
        }      

    }

    private void Update()
    {
        if (WorldGenerator.pause) {

            return;
        }

        if (this.name == ObjectName.BIRD && this.transform.position.x + birds_addend < WorldGenerator.x_pos)
        {
            SetBirdInWorld();
        }
        else if (this.name != ObjectName.BIRD && this.transform.position.x + blocks_addend < WorldGenerator.x_pos) {

            SetBlockInWorld();
        }
    }
}

enum Location {

    EMPTY = 0, UPPER = 1, LOWER = 2
}

enum ObjectName {

    BLOCK_0 = 0, BLOCK_1 = 1, BLOCK_2 = 2, BIRD = 3, BIRDS_GROUP = 4
}