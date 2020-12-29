using UnityEngine;

public class ForegroundObject : MonoBehaviour
{

    private const float addend = 10.0f;
    private static float x = WorldGenerator.x_pos + addend;
    private static bool isUpper = false;
    private static short upperBlocksCount = 0;
    private static short lowerBlocksCount = 0;

    public void SetInWorld() {

        float y = 0;
        
        Location location;

        if (isUpper)
        {
            isUpper = false;
            y = -2.5f;
            lowerBlocksCount++;
        }
        else {

            if (upperBlocksCount + lowerBlocksCount >= 7)
            {
                location = Location.EMPTY;
            }
            else if (upperBlocksCount == 1)
            {
                location = Location.UPPER;
            }
            else if (lowerBlocksCount == 1) {

                location = Location.LOWER;
            }
            else
            {
                int value = Random.Range(0, 5);

                if (value == 0 || value > 2)
                {
                    location = Location.EMPTY;
                }
                else {

                    location = (Location)value;
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

        if (y != 0) {

            transform.position = new Vector3(x, y, transform.position.z);
        }

        

        if (!isUpper) {

            x += 2.54f;
        }

        

    }

    void Update()
    {
        //transform.Translate(-1 * Time.deltaTime, 0, 0);

        if (this.transform.position.x + addend < WorldGenerator.x_pos) {

            SetInWorld();
        }


    }
}

enum Location {

    EMPTY = 0, UPPER = 1, LOWER = 2
}

