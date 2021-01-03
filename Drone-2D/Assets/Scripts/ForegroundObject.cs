using UnityEngine;

public class ForegroundObject : MonoBehaviour
{
    private static float addend = 10.0f;                                  // distance between camera position and edge of the screen        
    
    private static float blocks_x;                                         // current positions
    private static float upper_pos_y = -0.24f;
    private static float lower_pos_y = -2.5f;
    private static bool isUpper = false;                                  // is the last block was upper (level 2) ?
    private static short upperBlocksCount = 0;
    private static short lowerBlocksCount = 0;
    private static short maxBuldingSize = 7;                               // size in blocks
    private static float distanceBlocks = 2.54f;

    private static float birds_x;
    private static float distanceBirds = 5.0f;                             // distance between birds

    private void Start()
    {
        blocks_x = WorldGenerator.x_pos + addend;
        birds_x = WorldGenerator.x_pos + addend;
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

        birds_x = (birds_x < WorldGenerator.x_pos + addend) ? (WorldGenerator.x_pos + addend) : (birds_x + distanceBirds);
    }

    public void SetBlockInWorld() {

        float? y = null;

        Location location = Location.EMPTY;

        if (isUpper)
        {
            isUpper = false;
            y = lower_pos_y;
            lowerBlocksCount++;
        }
        else
        {
            if (upperBlocksCount + lowerBlocksCount >= maxBuldingSize)
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
                int value = Random.Range(0, 15);           // EMPTY 5-15  UPPER 0 LOWER 1-4

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
                y = upper_pos_y;
                upperBlocksCount++;
            }
            else if (location == Location.LOWER)
            {
                isUpper = false;
                y = lower_pos_y;
                lowerBlocksCount++;
            }

        }

        if (y != null) {

            transform.position = new Vector3(blocks_x, (float)y, transform.position.z);
        }
        
        if (!isUpper) {

            blocks_x += distanceBlocks;
        }      

    }

    private void Update()
    {
        if (WorldGenerator.pause) {

            return;
        }

        if (this.tag != "Block" && this.transform.position.x + addend < WorldGenerator.x_pos)
        {
            SetBirdInWorld();
        }
        else if (this.tag == "Block" && this.transform.position.x + addend < WorldGenerator.x_pos) {

            SetBlockInWorld();
        }
    }
}

enum Location {

    EMPTY = 0, UPPER = 1, LOWER = 2
}

